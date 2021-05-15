using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class DialogNode
{
    public const int DIALOG_SELECT_NODE = 0;
    public const int DIALOG_ACTION_NODE = 1;
    public const int DIALOG_GENERAL_NODE = 2;
    public const int DIALOG_END_NODE = 3;

    public int currentNodeType;

    public DialogNode(int currentNodeType)
    {
        this.currentNodeType = currentNodeType;
    }
    
    protected DialogNode nextDialogNode;
    
    public virtual DialogNode AddNextDialogNode(DialogNode dialogNode)
    {
        nextDialogNode = dialogNode;
        return nextDialogNode;
    }
    
    public virtual DialogNode GoNextDialogNode()
    {
        return nextDialogNode;
    }
    
    
}
