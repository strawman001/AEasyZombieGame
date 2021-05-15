using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorManager : MonoBehaviour
{
    private static DirectorManager instance = null;
    private DirectorManager(){}
    public static DirectorManager Instance
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
    
    private BaseTask mainSceneTask;
    
    private void Start()
    {
        switch (SceneManager.Instance.levelSceneIndex)
        {
            case 0:
                mainSceneTask = new MainTaskGraveScene();
                mainSceneTask.InitializeTask();
                break;
            case 1:
                mainSceneTask = new MainTaskCityScene();
                mainSceneTask.InitializeTask();
                break;
        }
    }
}
