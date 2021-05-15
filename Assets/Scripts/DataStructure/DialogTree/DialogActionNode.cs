using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActionNode:DialogNode
{
    private Action<Dictionary<string, object>> dialogAction;
    private DialogNode nextDialogNode;
    private Dictionary<string, object> param;

    public DialogActionNode(Action<Dictionary<string, object>> dialogAction,Dictionary<string, object> param) : base(DIALOG_ACTION_NODE)
    {
        this.dialogAction = dialogAction;
        this.param = param;
    }
    

    public void ExecuteNode()
    {
        dialogAction(param);
    } 
    
    
}
