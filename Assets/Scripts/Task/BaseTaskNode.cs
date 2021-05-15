using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Child Node of BaseTask
public abstract class BaseTaskNode : MonoBehaviour
{
    public BaseTask parentTask;
    public string taskNodeName;
    public string taskNodeDescription;
    public bool finishFlag = false;
    
    protected BaseTaskNode(BaseTask parentTask,string taskNodeName,string taskNodeDescription)
    {
        this.parentTask = parentTask;
        this.taskNodeDescription = taskNodeDescription;
        this.taskNodeName = taskNodeName;
    }

    public void CompleteTaskNode()
    {
        finishFlag = true;
    }
    
    public abstract void InitializeTaskNode();

    public abstract void ClearTaskNode();

}
