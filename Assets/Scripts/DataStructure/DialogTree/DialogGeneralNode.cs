using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGeneralNode : DialogNode
{
    private string dialogFragment;
    private DialogNode nextDialogNode;

    public DialogGeneralNode(string dialogFragment) : base(DIALOG_GENERAL_NODE)
    {
        this.dialogFragment = dialogFragment;
    }
    
    public string GetDialogFragment()
    {
        return dialogFragment;
    }
}
