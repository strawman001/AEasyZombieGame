using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameTaskImage;

    private void Start()
    {
        gameTaskImage = GetComponent<UIComponentManager>().GetUIComponent("TaskMenu");
    }

    public void OnTask(){
        Time.timeScale = 0;
        gameTaskImage.SetActive(true);
    }
    public void CloseTask(){
        Time.timeScale = 1f;
        gameTaskImage.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}