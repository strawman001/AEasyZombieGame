using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEndNode : DialogNode
{
    private DialogEndNode() : base(DIALOG_END_NODE)
    {
        
    }

    public static DialogEndNode Instance = new DialogEndNode();
    
    
}
