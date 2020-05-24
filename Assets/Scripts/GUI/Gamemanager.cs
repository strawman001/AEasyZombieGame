using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private int BrainNumber;
    private string sceneName;
    public void GoSelect()
    {
        SceneManager.LoadScene("SelectScene");
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoFirstLevel(){
        SceneManager.LoadScene("FirstGameScene");
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
}
