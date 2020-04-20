using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private string sceneName;
    public void GoSetting(){
        SceneManager.LoadScene("SettingScene"); 
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoStart(){
        SceneManager.LoadScene("NewgameScene"); 
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoLoad(){
        SceneManager.LoadScene("OldgameScene"); 
        sceneName = SceneManager.GetActiveScene().name;
    }
    public void GoCancel(){
        SceneManager.LoadScene("Cancel"); 
        sceneName = SceneManager.GetActiveScene().name;
    }
}
