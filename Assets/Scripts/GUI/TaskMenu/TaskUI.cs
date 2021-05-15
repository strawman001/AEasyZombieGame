using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    private static TaskUI instance = null;
    private TaskUI(){}
    public static TaskUI Instance
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
    
    
    
    public GameObject taskList;
    public GameObject taskDescriptionPanel;
    public GameObject taskNodeList;

    private TaskDescription taskDescription;
    private GameObject taskItem;
    private GameObject taskNodePanel;
    private Dictionary<string, BaseTask> activeTaskDictionary;
    private Dictionary<string, BaseTask> finishedTaskDictionary;
    private bool isFirstElement = true;
    
    private void Start()
    {
        taskDescription = taskDescriptionPanel.GetComponent<TaskDescription>();
        taskItem = Resources.Load("Prefab/UI/TaskItem") as GameObject;
        taskNodePanel = Resources.Load("Prefab/UI/TaskNodePanel") as GameObject;
        activeTaskDictionary = TaskController.Instance.activeTaskDictionary;
        finishedTaskDictionary = TaskController.Instance.finishedTaskDictionary;

    }

    public void UpdateTaskUI()
    {
        ClearTaskListView();
        foreach (KeyValuePair<string,BaseTask> keyValuePair in activeTaskDictionary)
        {
            BaseTask baseTask = keyValuePair.Value;
            GameObject taskItemIns = Instantiate(taskItem);
            taskItemIns.transform.parent = taskList.transform;
            taskItemIns.GetComponent<Button>().onClick.AddListener(delegate()
            {
                ShowTaskContent(keyValuePair.Key);
            });
            taskItemIns.GetComponent<TaskItem>().SetTaskItem(baseTask.taskTitle,baseTask.taskName,false);
            if (isFirstElement)
            {
                isFirstElement = false;
                ShowTaskContent(keyValuePair.Key);
            }
            
        }
        foreach (KeyValuePair<string,BaseTask> keyValuePair in finishedTaskDictionary)
        {
            BaseTask baseTask = keyValuePair.Value;
            GameObject taskItemIns = Instantiate(taskItem, taskList.transform, true);
            taskItemIns.GetComponent<TaskItem>().SetTaskItem(baseTask.taskTitle,baseTask.taskName,true);
        }
    }

    public void ShowTaskContent(string itemKey)
    {
        ClearTAskNodeListView();
        BaseTask baseTask;
        if (activeTaskDictionary[itemKey]==null)
        {
            baseTask = activeTaskDictionary[itemKey];
        }
        else
        {
            baseTask = finishedTaskDictionary[itemKey];
        }
        
        taskDescription.SetTaskDescription(baseTask.taskTitle,baseTask.taskName,baseTask.taskDescription);
        if (baseTask.taskNodeList!=null)
        {
            foreach (BaseTaskNode baseTaskNode in baseTask.taskNodeList)
            {
                GameObject taskNodePanelIns = Instantiate(taskNodePanel, taskNodeList.transform, true);
                taskNodePanelIns.GetComponent<TaskNodePanel>().SetTaskNodePanel(baseTaskNode.taskNodeName,baseTaskNode.taskNodeDescription,baseTaskNode.finishFlag);
            }
        }
        else
        {
            GameObject taskNodePanelIns = Instantiate(taskNodePanel, taskNodeList.transform, true);
            taskNodePanelIns.GetComponent<TaskNodePanel>().SetTaskNodePanel(baseTask.taskName,baseTask.taskDescription,false);
        }
        
    }

    public void ClearTaskListView()
    {
        for (int i = 0; i < taskList.transform.childCount; i++)
        {
            Destroy(taskList.transform.GetChild(i).gameObject);
        }
    }

    public void ClearTAskNodeListView()
    {
        for (int i = 0; i < taskNodeList.transform.childCount; i++)
        {
            Destroy(taskNodeList.transform.GetChild(i).gameObject);
        }
    }
}
