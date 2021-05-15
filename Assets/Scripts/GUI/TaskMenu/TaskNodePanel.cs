using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskNodePanel : MonoBehaviour
{
    public GameObject tick;
    public GameObject taskNodeName;
    public GameObject taskNodeDescription;

    public void SetTaskNodePanel(string taskNodeNameText,string taskNodeDescriptionText,bool isFinished)
    {
        taskNodeName.GetComponent<Text>().text = taskNodeNameText;
        taskNodeDescription.GetComponent<Text>().text = taskNodeDescriptionText;
        if (isFinished)
        {
            tick.SetActive(true);
        }
    }
    
}
