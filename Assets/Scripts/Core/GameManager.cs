using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static ConcurrentQueue<string> messageList = new ConcurrentQueue<string>();
    private bool isDealing = false;
    private LevelMenuController levelMenuController;
    private BrainBar brainBar;
    
    public static GlobalData globalData;
    public GameObject uiController;
    public int target;
    private void Start()
    {
        globalData = new GlobalData(0,target);
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
        levelMenuController = uiController.GetComponent<LevelMenuController>();
        levelMenuController.GameOver();
    }

    public void PassLevel()
    {
        levelMenuController = uiController.GetComponent<LevelMenuController>();
        levelMenuController.LevelPass();
    }

    public void BrainAddOne()
    {
        globalData.brain += 1;
        Debug.Log(globalData.brain);
        if (globalData.brain == globalData.target)
        {
            AddMessage("PassLevel");
        }
    }

    public static void AddMessage(String message)
    {
        messageList.Enqueue(message);
    }

   
    
}
