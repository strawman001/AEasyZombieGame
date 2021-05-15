using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskListener
{
    private TaskMessage taskMessage;

    public TaskListener(TaskMessage taskMessage)
    {
        this.taskMessage = taskMessage;
    }
    
    public void SendMessage()
    {
        TaskController.Instance.AddMessage(taskMessage);
    }
}