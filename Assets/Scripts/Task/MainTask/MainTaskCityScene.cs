using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTaskCityScene : BaseTask
{
   private SphereTrigger sphereTrigger;
    private GameObject sphereCollider;
    
    public MainTaskCityScene():base("MainTaskCityScene")
    {
        taskName = "Back to reality";
        taskDescription = "Run out of the City";
        taskTitle = "Main Task";
    }
    
    public override void InitializeTask()
    {
        
        base.InitializeTask();
        sphereCollider = Resources.Load("Prefab/Trigger/SphereTrigger") as GameObject;
        GameObject temp = Instantiate(sphereCollider,new Vector3(-7.5f,0,157),sphereCollider.transform.rotation);
        sphereTrigger = temp.GetComponent<SphereTrigger>();
        temp.GetComponent<SphereCollider>().radius = 8;
        sphereTrigger.SetTriggerEnter(delegate
        {
            TaskMessage taskMessage = new TaskMessage(MessageType.TASK_UPDATE,"MainTaskCityScene");
            TaskController.Instance.AddMessage(taskMessage);
        });

    }
    
    public override void UpdateTaskStatus(Dictionary<string, object> param)
    {
        TaskCompleted();
    }

    public override void TaskCompleted()
    {
        base.TaskCompleted();
        GameManager.AddMessage("PassLevel");
    }
}
