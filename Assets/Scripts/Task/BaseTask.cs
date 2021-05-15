using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public abstract class BaseTask : MonoBehaviour
{
    public string taskKey;
    public string taskTitle;
    public string taskName;
    public string taskDescription;
    public List<BaseTaskNode> taskNodeList;
    public bool isFinished = false;
    
    protected BaseTask(string taskKey)
    {
        this.taskKey = taskKey;
    }
    
    public virtual void InitializeTask()
    {
        TaskController.Instance.AddMessage(new TaskMessage(MessageType.TASK_BEGIN,taskKey,this));
    }

    public abstract void UpdateTaskStatus(Dictionary<String,Object> @params);

    public virtual void TaskCompleted()
    {
        isFinished = true;
        TaskController.Instance.AddMessage(new TaskMessage(MessageType.TASK_COMPLETED,taskKey,this));
    }
}
