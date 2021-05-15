using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDialog : MonoBehaviour
{
    private DialogTree dialogTree;
    
    private void Start()
    {
        dialogTree = InitDialogTree();
    }

    public abstract DialogTree InitDialogTree();

    public DialogTree GetDialogTree()
    {
        return dialogTree;
    }
}
