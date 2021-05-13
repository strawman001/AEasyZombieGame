using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelNode : ControlNode
{
    public override bool Execute()
    {
        foreach (Node node in childrenNodeList)
        {
            node.Execute();

        }
        return true;
    }
}
