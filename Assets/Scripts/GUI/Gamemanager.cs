using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public int levelIndex;
    
    private int brainNumber;
    private string sceneName;
    private string[] levelName; 
    
    private void Start()
    {
       levelName = new string[]{"GameSceneDemo","SecondGameScene","ThirdGameScene"};
    }

    public void GoSelect()
    {
        SceneManager.LoadScene("SelectScene");
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoFirstLevel(){
        SceneManager.LoadScene("GameSceneDemo");
       // int BrainNumber = 0;
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoSecondLevel(){
        SceneManager.LoadScene("SecondGameScene");
        // int BrainNumber = 0;
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoThirdLevel(){
        SceneManager.LoadScene("ThirdGameScene");
        // int BrainNumber = 0;
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoMain(){
        SceneManager.LoadScene("MainScene"); 
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void GoNextLevel()
    {
        SceneManager.LoadScene(levelName[levelIndex+1]);
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void ResetTheLevel()
    {
        SceneManager.LoadScene(levelName[levelIndex]);
        sceneName = SceneManager.GetActiveScene().name;
    }
}
