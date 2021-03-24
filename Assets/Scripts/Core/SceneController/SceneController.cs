using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int levelSceneIndex;

    private string sceneName;
    private static string[] levelScenesName = {"GraveGameScene","CityGameScene"};
    private static string[] menuScenesName = {"TransitionScene", "MainScene", "SelectScene"};
    
    public static int targetLevelIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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

