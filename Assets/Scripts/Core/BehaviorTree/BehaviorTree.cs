using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{
    private Node rootNode;
    public bool isExecuting = false;
    public string lastActionNodeName = "";
    public ActionNode lastActionNode = ActionNode.NullActionNode;

    public BehaviorTree(Node rootNode)
    {
        this.rootNode = rootNode;
    }

    public void Tick()
    {
        rootNode.Execute();
    }

    public static ActionNode MakeNoParamActionNode(BehaviorTree tree, String name,Action action)
    {
        return new ActionNode(tree,name, (Dictionary<string, object> dictionary) => { action(); return true;},null);
            
            
    }
    
    public static ConditionNode MakeNoParamConditionNode(Func<bool> action)
    {
        return new ConditionNode((Dictionary<string, object> dictionary) =>
        {
            return action();
        }, null);
    }
    
}
