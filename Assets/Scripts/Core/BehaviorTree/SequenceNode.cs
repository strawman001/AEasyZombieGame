using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : ControlNode
{
    public override bool Execute()
    {
        foreach (Node node in childrenNodeList)
        {
            if (!node.Execute())
            {
                return false;
            }
        }

        return true;
    }
}
