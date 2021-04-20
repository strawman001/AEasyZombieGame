using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//deprecated
public class DecorationNode : Node
{
    // private Node coreNode;
    // private Action<Dictionary<string, object>> preAction;
    // private Action<Dictionary<string, object>> afterAction;
    // private Dictionary<string, object> preActionParams;
    // private Dictionary<string, object> afterActionParams;
    // private BehaviorTree tree;
    //
    // DecorationNode(BehaviorTree tree,Node coreNode, Action<Dictionary<string, object>> preAction,Dictionary<string, object> preActionParams,
    //     Action<Dictionary<string, object>> afterAction, Dictionary<string,object> afterActionParams)
    // {
    //     this.tree = tree;
    //     this.coreNode = coreNode;
    //     this.preAction = preAction;
    //     this.afterAction = afterAction;
    //     this.preActionParams = preActionParams;
    //     this.afterActionParams = afterActionParams;
    // }
    //
    // public override bool Execute()
    // {
    //     preAction(preActionParams);
    //     bool temp = coreNode.Execute();
    //     afterAction(afterActionParams);
    //
    //     return temp;
    // }
    public override bool Execute()
    {
        throw new NotImplementedException();
    }
}
