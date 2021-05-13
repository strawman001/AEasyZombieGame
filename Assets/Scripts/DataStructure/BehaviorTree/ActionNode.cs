using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ActionNode : Node
{
    private Func<Dictionary<string,object>,bool> executeFunction = (Dictionary<string, object> dir) => { return false;};
    private Dictionary<string,object> paramDic;
    private BehaviorTree tree;
    private Action<Dictionary<string, object>> preAction = (Dictionary<string, object> dir) => {};
    private Action<Dictionary<string, object>> afterAction = (Dictionary<string, object> dir) => {};
    private Dictionary<string, object> preActionParams = null;
    private Dictionary<string, object> afterActionParams = null;
    
    public static ActionNode NullActionNode = new ActionNode(null,"NULL",null,null);

    public ActionNode(BehaviorTree tree,string nodeName,Func<Dictionary<string,object>,bool> executeFunction,Dictionary<string,object> paramDic)
    {
        this.tree = tree;
        this.nodeName = nodeName;
        this.executeFunction = executeFunction;
        this.paramDic = paramDic;
    }

    public ActionNode SetEnterMethod(Action<Dictionary<string, object>> preAction,Dictionary<string, object> preActionParams)
    {
        this.preAction = preAction;
        this.preActionParams = preActionParams;
        return this;
    }
    
    public ActionNode SetLeaveMethod(Action<Dictionary<string, object>> afterAction,Dictionary<string, object> afterActionParams)
    {
        this.afterAction = afterAction;
        this.afterActionParams = afterActionParams;
        return this;
    }
    
    public ActionNode SetEnterMethod(Action preAction)
    {
        this.preAction = (Dictionary<string,object> temp) => { preAction(); };
        return this;
    }
    
    public ActionNode SetLeaveMethod(Action afterAction)
    {
        this.afterAction = (Dictionary<string,object> temp) => { afterAction(); };
        this.afterActionParams = afterActionParams;
        return this;
    }
    
    public void EnterNode()
    {
        preAction(preActionParams);
    }

    public void LeaveNode()
    {
        afterAction(afterActionParams);
    }
    
    public override bool Execute()
    {
        if (tree.lastActionNodeName!=this.nodeName)
        {
            tree.lastActionNodeName = this.nodeName;
            tree.lastActionNode.LeaveNode();
            EnterNode();
            tree.lastActionNode = this;
        }
        return executeFunction(paramDic);
    }
}
