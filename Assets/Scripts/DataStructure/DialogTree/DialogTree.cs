using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class DialogTree
{
    private DialogNode root;
    private DialogNode currentDialogNode;

    public DialogTree(DialogNode root)
    {
        this.root = root;
        currentDialogNode = root;
    }
    

    public DialogNode GetCurrentDialogNode()
    {
        return currentDialogNode;
    }

    public void ChangeRoot(DialogNode dialogNode)
    {
        root = dialogNode;
        currentDialogNode = root;
    }

    public Dictionary<string,Object> GetCurrentDialogNodeInfo()
    {
        Dictionary<string,Object> returnDic = new Dictionary<string, object>();
        
        switch (currentDialogNode.currentNodeType)
        {
            case DialogNode.DIALOG_GENERAL_NODE:
                DialogGeneralNode dialogGeneralNode = (DialogGeneralNode) currentDialogNode;
                returnDic.Add("Type",DialogNode.DIALOG_GENERAL_NODE);
                returnDic.Add("Data",dialogGeneralNode.GetDialogFragment());
                break;
            case DialogNode.DIALOG_SELECT_NODE:
                DialogSelectNode dialogSelectNode = (DialogSelectNode) currentDialogNode;
                returnDic.Add("Type",DialogNode.DIALOG_SELECT_NODE);
                returnDic.Add("Data",dialogSelectNode.GetSelectItem());
                break;
            case DialogNode.DIALOG_ACTION_NODE:
                DialogActionNode dialogActionNode = (DialogActionNode) currentDialogNode;
                dialogActionNode.ExecuteNode();
                currentDialogNode = dialogActionNode.GoNextDialogNode();
                return GetCurrentDialogNodeInfo();
            case DialogNode.DIALOG_END_NODE:
                returnDic.Add("Type", DialogNode.DIALOG_END_NODE);
                currentDialogNode = root;
                break;
        }

        return returnDic;
    }

    public void GoNextDialogNode()
    {
        switch (currentDialogNode.currentNodeType)
        {
            case DialogNode.DIALOG_GENERAL_NODE:
                DialogGeneralNode dialogGeneralNode = (DialogGeneralNode) currentDialogNode;
                currentDialogNode = dialogGeneralNode.GoNextDialogNode();
                break;
            case DialogNode.DIALOG_SELECT_NODE:
                DialogSelectNode dialogSelectNode = (DialogSelectNode) currentDialogNode;
                currentDialogNode = dialogSelectNode.GoNextDialogNode(0);
                break;
            case DialogNode.DIALOG_ACTION_NODE:
                DialogActionNode dialogActionNode = (DialogActionNode) currentDialogNode;
                currentDialogNode = dialogActionNode.GoNextDialogNode();
                break;
            case DialogNode.DIALOG_END_NODE:
                break;
        }
    }
    
    public void GoNextDialogNode(int position)
    {
        switch (currentDialogNode.currentNodeType)
        {
            case DialogNode.DIALOG_SELECT_NODE:
                DialogSelectNode dialogSelectNode = (DialogSelectNode) currentDialogNode;
                currentDialogNode = dialogSelectNode.GoNextDialogNode(position);
                break;
        }
    }

    public static DialogGeneralNode MakeDialogGeneralNode(string dialogFragment)
    {
        return new DialogGeneralNode(dialogFragment);
    }
    
    public static DialogSelectNode MakeDialogSelectNode(List<string> dialogSelectItem,List<DialogNode> dialogNextNodeList)
    {
        return new DialogSelectNode(dialogSelectItem,dialogNextNodeList);
    }
    
    public static DialogActionNode MakeDialogActionNode(Action<Dictionary<string, object>> dialogAction,Dictionary<string, object> param)
    {
        return new DialogActionNode(dialogAction,param);
    }

    public static DialogActionNode MakeNoParamActionNode(Action method)
    {
        return new DialogActionNode(delegate(Dictionary<string, object> objects) { method(); },null );
    }
    
}
