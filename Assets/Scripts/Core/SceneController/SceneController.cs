using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int levelSceneIndex;

    private static string[] menuScenesName = {"TransitionScene", "MainScene", "SelectScene"};
    
    public static int targetLevelIndex = 0;
    

    //Switch to a transition scene to load game scene async
    public void SwitchLevelScene(int levelIndex)
    {
        targetLevelIndex = levelIndex;
        SceneManager.LoadScene(menuScenesName[0]);
        
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
        SceneManager.LoadScene(menuScenesName[1]);
    }
    
    public void GoSelectScene()
    {
        SceneManager.LoadScene(menuScenesName[2]);
    }

    public void ExitGame()
    {

        Application.Quit();
    }
}

