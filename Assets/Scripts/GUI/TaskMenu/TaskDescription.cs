using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskDescription : MonoBehaviour
{
    public GameObject taskTitle;
    public GameObject taskName;
    public GameObject taskDescription;

    public void SetTaskDescription(string taskTitleText,string taskNameText,string taskDescriptionText)
    {
        taskTitle.GetComponent<Text>().text = taskTitleText;
        taskName.GetComponent<Text>().text = taskNameText;
        taskDescription.GetComponent<Text>().text = taskDescriptionText;
    }
}
