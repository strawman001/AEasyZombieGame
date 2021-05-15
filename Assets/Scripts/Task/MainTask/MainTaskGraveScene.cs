using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Item;
using UnityEngine;
using Object = System.Object;

public class MainTaskGraveScene : BaseTask
{
    //public int brainNumber = 0;

    private SphereTrigger sphereTrigger;
    private GameObject sphereCollider;
    
    public MainTaskGraveScene():base("MainTaskGravityScene")
    {
        taskName = "Back to reality";
        taskDescription = "Run out of the Grave";
        taskTitle = "Main Task";
    }
    
    public override void InitializeTask()
    {
        /*base.InitializeTask();
        GameObject policePrefab = Resources.Load("Prefab/Enemy/Police") as GameObject;
        GameObject police = Instantiate(policePrefab, new Vector3(105, 12, 78),policePrefab.transform.rotation);
        PoliceController policeController = police.GetComponent<PoliceController>();
        policeController.attackDistence = 30.0f;
        policeController.viewDistence = 40.0f;
        policeController.patrolPoints = new[] {new Vector3(140, 13, 92), new Vector3(65, 13, 92)};
        TaskMessage taskMessage = new TaskMessage(MessageType.TASK_UPDATE,"MainTaskGravityScene");
        police.GetComponent<HumanInterface>().taskObserver.AddListener(ObjectEventType.EVENT_DIE,new TaskListener(taskMessage));
        
        GameObject peoplePrefab = Resources.Load("Prefab/Enemy/People") as GameObject;
        GameObject people = Instantiate(peoplePrefab, new Vector3(114, 12, 152),peoplePrefab.transform.rotation);
        PeopleController peopleController = people.GetComponent<PeopleController>();
        peopleController.attackDistence = 15.0f;
        peopleController.viewDistence = 40.0f;
        peopleController.patrolPoints = new[] {new Vector3(65, 13, 150), new Vector3(140, 13, 150)};
        people.GetComponent<HumanInterface>().taskObserver.AddListener(ObjectEventType.EVENT_DIE,new TaskListener(taskMessage));*/
        
        base.InitializeTask();
        sphereCollider = Resources.Load("Prefab/Trigger/SphereTrigger") as GameObject;
        GameObject temp = Instantiate(sphereCollider,new Vector3(120,12,21),sphereCollider.transform.rotation);
        sphereTrigger = temp.GetComponent<SphereTrigger>();
        sphereTrigger.SetTriggerEnter(delegate
        {
            TaskMessage taskMessage = new TaskMessage(MessageType.TASK_UPDATE,"MainTaskGravityScene");
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
