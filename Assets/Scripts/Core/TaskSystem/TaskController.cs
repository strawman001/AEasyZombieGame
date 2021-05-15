using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    private static TaskController instance = null;
    private TaskController(){}
    public static TaskController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private Queue<TaskMessage> taskMessageQueue= new Queue<TaskMessage>();
    public Dictionary<string,BaseTask> activeTaskDictionary = new Dictionary<string, BaseTask>();
    public Dictionary<string,BaseTask> finishedTaskDictionary = new Dictionary<string, BaseTask>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DealMessage();
    }

    public void AddMessage(TaskMessage taskMessage)
    {
        taskMessageQueue.Enqueue(taskMessage);
    }

    private void DealMessage()
    {
        if (taskMessageQueue.Count>0)
        {
            TaskMessage taskMessage = taskMessageQueue.Dequeue();
            if (taskMessage.messageType.Equals(MessageType.TASK_BEGIN))
            {
                activeTaskDictionary.Add(taskMessage.taskKey,taskMessage.baseTask);
                UserMessageManager.Instance.AddUserMessage("New Task:" + taskMessage.baseTask.taskName);
            }
            else if (taskMessage.messageType.Equals(MessageType.TASK_COMPLETED))
            {
                activeTaskDictionary.Remove(taskMessage.taskKey);
                finishedTaskDictionary.Add(taskMessage.taskKey,taskMessage.baseTask);
                UserMessageManager.Instance.AddUserMessage("Completed Task:" + taskMessage.baseTask.taskName);
            }
            else
            {
                activeTaskDictionary[taskMessage.taskKey].UpdateTaskStatus(taskMessage.paramDictionary);
            }
            
        }
        
    }
}
