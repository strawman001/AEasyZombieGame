using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance = null;
    private SceneManager(){}
    public static SceneManager Instance
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

    public int levelSceneIndex;

    private static string[] menuScenesName = {"TransitionScene", "MainScene", "SelectScene"};
    
    public static int targetLevelIndex = 0;
    
    public static Dictionary<int,LevelInfo> LevelInfoDir = new Dictionary<int, LevelInfo>()
    {
        {0,new LevelInfo(2)},
        {1,new LevelInfo(2)}
    };
    
    //Switch to a transition scene to load game scene async
    public void SwitchLevelScene(int levelIndex)
    {
        targetLevelIndex = levelIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(menuScenesName[0]);
        
    }

    public void ResetLevelScene()
    {
        SwitchLevelScene(levelSceneIndex);
    }

    public void GoNextLevelScene()
    {
        SwitchLevelScene(levelSceneIndex+1);
    }

    public void GoMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(menuScenesName[1]);
    }
    
    public void GoSelectScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(menuScenesName[2]);
    }

    public void ExitGame()
    {

        Application.Quit();
    }
}

