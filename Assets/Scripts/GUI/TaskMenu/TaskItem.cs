using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour
{
    public GameObject taskTitle;
    public GameObject taskName;
    public GameObject taskImage;
    public GameObject finishedImage;

    public string tagKey;
    
    private void Start()
    {
       
    }

    public void SetTaskItem(string taskTitleText,string taskNameText,bool isFinished)
    {
        taskTitle.GetComponent<Text>().text = taskTitleText;
        taskName.GetComponent<Text>().text = taskNameText;
        if (isFinished)
        {
            taskImage.SetActive(false);
            finishedImage.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color(0.6f,0.6f,0.6f,1);
        }
        else
        {
            taskImage.SetActive(true);
            finishedImage.SetActive(false);
        }
    }
}
