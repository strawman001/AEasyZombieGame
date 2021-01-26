using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMenu : MonoBehaviour
{
    private GameObject sceneController;
    private SceneController sceneControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneController = GetComponent<UIComponentManager>().GetUIComponent("SceneController");
        sceneControllerScript = sceneController.GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SwitchLevelScene(int levelIndex)
    {
       sceneControllerScript.SwitchLevelScene(levelIndex);
    }

    public void ResetLevelScene()
    {
        sceneControllerScript.ResetLevelScene();
    }

    public void GoNextLevelScene()
    {
        sceneControllerScript.GoNextLevelScene();
    }

    public void GoMainScene()
    {
        sceneControllerScript.GoMainScene();
    }
    
    public void GoSelectScene()
    {
        sceneControllerScript.GoSelectScene();
    }

    public void ExitGame()
    {
        sceneControllerScript.ExitGame();
    }
}
