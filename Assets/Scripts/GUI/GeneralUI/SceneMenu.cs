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
       _sceneManagerScript.SwitchLevelScene(levelIndex);
    }

    public void ResetLevelScene()
    {
        _sceneManagerScript.ResetLevelScene();
    }

    public void GoNextLevelScene()
    {
        _sceneManagerScript.GoNextLevelScene();
    }

    public void GoMainScene()
    {
        _sceneManagerScript.GoMainScene();
    }
    
    public void GoSelectScene()
    {
        _sceneManagerScript.GoSelectScene();
    }

    public void ExitGame()
    {
        _sceneManagerScript.ExitGame();
    }
}
