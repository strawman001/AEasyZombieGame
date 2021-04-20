using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : ControlNode
{
    public override bool Execute()
    {
        foreach (Node node in childrenNodeList)
        {
            if (node.Execute())
            {
                return true;
            }
        }

        return false;
    }
}
