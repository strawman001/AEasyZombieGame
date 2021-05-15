using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMenu : MonoBehaviour
{
    private GameObject sceneController;
    private SceneManager _sceneManagerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneController = GetComponent<UIComponentManager>().GetUIComponent("SceneManager");
        _sceneManagerScript = sceneController.GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SwitchLevelScene(int levelIndex)
    {
        Time.timeScale = 1f;
       _sceneManagerScript.SwitchLevelScene(levelIndex);
    }

    public void ResetLevelScene()
    {
        Time.timeScale = 1f;
        _sceneManagerScript.ResetLevelScene();
    }

    public void GoNextLevelScene()
    {
        Time.timeScale = 1f;
        _sceneManagerScript.GoNextLevelScene();
    }

    public void GoMainScene()
    {
        Time.timeScale = 1f;
        _sceneManagerScript.GoMainScene();
    }
    
    public void GoSelectScene()
    {
        Time.timeScale = 1f;
        _sceneManagerScript.GoSelectScene();
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        _sceneManagerScript.ExitGame();
    }
}
