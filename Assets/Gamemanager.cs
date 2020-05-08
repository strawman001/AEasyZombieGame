using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private int BrainNumber;
    private string sceneName;
    public void GoSetting(){
        SceneManager.LoadScene("SettingScene"); 
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoStart(){
        SceneManager.LoadScene("FirstGameScene");
       // int BrainNumber = 0;
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoMain(){
        SceneManager.LoadScene("MainScene"); 
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoInform()
    {
        SceneManager.LoadScene("InformationScene");
        sceneName = SceneManager.GetActiveScene().name;
    }
}
