using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTaskGraveScene : BaseTask
{
    public int brainNumber = 0;
    
    public SideTaskGraveScene():base("SideTaskGraveScene")
    {
        taskName = "Help Grave Keeper";
        taskDescription = "Kill two soul shadows";
        taskTitle = "Side Task";
    }

    public override void InitializeTask()
    {
        base.InitializeTask();
        GameObject policePrefab = Resources.Load("Prefab/Enemy/Police") as GameObject;
        GameObject police = Instantiate(policePrefab, new Vector3(105, 12, 78),policePrefab.transform.rotation);
        PoliceController policeController = police.GetComponent<PoliceController>();
        policeController.attackDistence = 30.0f;
        policeController.viewDistence = 40.0f;
        policeController.patrolPoints = new[] {new Vector3(140, 13, 92), new Vector3(65, 13, 92)};
        TaskMessage taskMessage = new TaskMessage(MessageType.TASK_UPDATE,"SideTaskGraveScene");
        police.GetComponent<HumanInterface>().taskObserver.AddListener(ObjectEventType.EVENT_DIE,new TaskListener(taskMessage));
        
        GameObject peoplePrefab = Resources.Load("Prefab/Enemy/People") as GameObject;
        GameObject people = Instantiate(peoplePrefab, new Vector3(114, 12, 152),peoplePrefab.transform.rotation);
        PeopleController peopleController = people.GetComponent<PeopleController>();
        peopleController.attackDistence = 15.0f;
        peopleController.viewDistence = 40.0f;
        peopleController.patrolPoints = new[] {new Vector3(65, 13, 150), new Vector3(140, 13, 150)};
        people.GetComponent<HumanInterface>().taskObserver.AddListener(ObjectEventType.EVENT_DIE,new TaskListener(taskMessage));
    }
    
    
    public override void UpdateTaskStatus(Dictionary<string, object> @params)
    {
        brainNumber++;
        if (brainNumber==2)
        {
            isFinished = true;
        }
    }
    
    public override void TaskCompleted()
    {
        base.TaskCompleted();
        BackpackManager.Instance.AddItemToBackpack("Item.LifeBond",1);
    }
}
