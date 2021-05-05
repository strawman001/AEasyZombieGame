using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControlNode : Node
{
    public List<Node> childrenNodeList = new List<Node>();

    public ControlNode AddNode(Node childrenNode)
    {
        childrenNodeList.Add(childrenNode);
        return this;
    }
}
