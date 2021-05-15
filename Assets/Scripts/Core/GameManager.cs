using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private GameManager(){}
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    
    private static ConcurrentQueue<string> messageList = new ConcurrentQueue<string>();
    private bool isDealing = false;
    private LevelMenuController levelMenuController;
    private BrainBar brainBar;

    public LevelData levelData;
    public static Assembly assembly = typeof(GameManager).Assembly;
    public GameObject uiController;

    private void Awake()
    {
        instance = this;
        
        assembly = typeof(GameManager).Assembly;
    }

    private void Start()
    {
        levelData = new LevelData(SceneManager.LevelInfoDir[SceneManager.Instance.levelSceneIndex]);
    }

    private void Update()
    {
        if (!messageList.IsEmpty&&!isDealing)
        {
            DealMessage();
        }
    }

    public void DealMessage()
    {
        while (messageList.Count!=0)
        {
            string key = "";
            messageList.TryDequeue(out key);
            if (key.Equals("PassLevel"))
            {
                PassLevel();
            }
            else if(key.Equals("GameOver"))
            {
                GameOver();
            }
            else if(key.Equals("BrainAddOne"))
            {
                BrainAddOne();
            }
        }
        isDealing = false;
    }
    
    public void GameOver()
    {
        Time.timeScale = 0f;
        levelMenuController = uiController.GetComponent<LevelMenuController>();
        levelMenuController.GameOver();
    }

    public void PassLevel()
    {
        Time.timeScale = 0f;
        levelMenuController = uiController.GetComponent<LevelMenuController>();
        levelMenuController.LevelPass();
    }

    public void BrainAddOne()
    {
        // levelData.AddOneBrain();
        // UserMessageManager.Instance.AddUserMessage("Get a new brain.");
        // BrainBar.Instance.UpdateBrainNum();
        // if (levelData.currentBrainNum == levelData.targetBrainNum)
        // {
        //     AddMessage("PassLevel");
        // }
    }

    public static void AddMessage(String message)
    {
        messageList.Enqueue(message);
    }

   
    
}
