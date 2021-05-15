using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class TaskMessage
{
    public string messageType;
    public string taskKey;
    public Dictionary<String, Object> paramDictionary;
    public BaseTask baseTask;

    public TaskMessage(string messageType,string taskKey,Dictionary<String, Object> paramDictionary)
    {
        this.messageType = messageType;
        this.taskKey = taskKey;
        this.paramDictionary = paramDictionary;
    }
    
    public TaskMessage(string messageType,string taskKey)
    {
        this.messageType = messageType;
        this.taskKey = taskKey;
    }
    
    public TaskMessage(string messageType,string taskKey,BaseTask baseTask)
    {
        this.messageType = messageType;
        this.taskKey = taskKey;
        this.baseTask = baseTask;
    }
}
