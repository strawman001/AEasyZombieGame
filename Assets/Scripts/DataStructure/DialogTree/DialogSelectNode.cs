using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSelectNode:DialogNode
{
    private List<DialogNode> dialogNextNodeList;
    private List<string> dialogSelectItemList;
    
    public DialogSelectNode() : base(DIALOG_SELECT_NODE)
    {
        dialogNextNodeList = new List<DialogNode>();
        dialogSelectItemList = new List<string>();
    }
    
    public DialogSelectNode(List<string> dialogSelectItemList,List<DialogNode> dialogNextNodeList) : base(DIALOG_SELECT_NODE)
    {
        this.dialogNextNodeList = dialogNextNodeList;
        this.dialogSelectItemList = dialogSelectItemList;
        if (dialogSelectItemList.Count!=dialogNextNodeList.Count)
        {
            throw new Exception("Exception: Cannot create DialogSelectNode with unpaired select item.\n Hint: two lists have different length.");
        }
    }
    
    public DialogSelectNode(string dialogSelectItem) : base(DIALOG_SELECT_NODE)
    {
        dialogNextNodeList = new List<DialogNode>();
        dialogSelectItemList = new List<string>();
        dialogSelectItemList.Add(dialogSelectItem);
    }

    public DialogNode AddNextDialogNodePair(string dialogItem,DialogNode dialogNode)
    {
        dialogSelectItemList.Add(dialogItem);
        dialogNextNodeList.Add(dialogNode);
        return dialogNode;
    }
    
    public DialogNode GoNextDialogNode(int index)
    {
        return dialogNextNodeList[index];
    }
    
    public override DialogNode AddNextDialogNode(DialogNode dialogNode)
    {
        nextDialogNode = dialogNode;
        dialogNextNodeList.Add(dialogNode);
        return dialogNode;
    }
    
    public override DialogNode GoNextDialogNode()
    {
        return dialogNextNodeList[0];
    }

    public List<string> GetSelectItem()
    {
        return dialogSelectItemList;
    }

}
