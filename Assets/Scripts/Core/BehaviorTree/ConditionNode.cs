using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionNode : Node
{
    
    private Func<Dictionary<string,object>,bool> executeFunction;
    private Dictionary<string,object> paramDic;

    public ConditionNode(Func<Dictionary<string,object>,bool> executeFunction,Dictionary<string,object> paramDic)
    {
        this.executeFunction = executeFunction;
        this.paramDic = paramDic;
    }
    

    public override bool Execute()
    {
        return executeFunction(paramDic);
    }
}
