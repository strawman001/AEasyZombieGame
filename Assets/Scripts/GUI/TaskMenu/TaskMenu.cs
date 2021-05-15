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
        TaskUI.Instance.UpdateTaskUI();
        gameTaskImage.GetComponent<CanvasGroup>().alpha = 1;
        gameTaskImage.GetComponent<CanvasGroup>().interactable = true;
        gameTaskImage.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void CloseTask(){
        Time.timeScale = 1f;
        gameTaskImage.GetComponent<CanvasGroup>().alpha = 0;
        gameTaskImage.GetComponent<CanvasGroup>().interactable = false;
        gameTaskImage.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}