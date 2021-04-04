using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public float loadingProcess = 0.0f;
    public bool enterFlag = false;

    public Slider slider;
    public GameObject buttonEnterGame;
    
    private static string[] levelScenesName = {"GraveGameScene","CityGameScene", "DessertGameScene" };
    
    private int targetLevelIndex;

    // Start is called before the first frame update
    void Start()
    {
        targetLevelIndex = SceneController.targetLevelIndex;
        StartCoroutine(LoadLevelSceneAsync());
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = loadingProcess;
    }
    
    //Load scene async
    private IEnumerator LoadLevelSceneAsync()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(levelScenesName[targetLevelIndex]);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            if (async.progress < 0.9f)
                loadingProcess = async.progress;
            else
            {
                loadingProcess = 1.0f;
                buttonEnterGame.SetActive(true);
                if (enterFlag)
                    async.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void EnterGame()
    {
        enterFlag = true;
    }
}
