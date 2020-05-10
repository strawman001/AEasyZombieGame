using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
  //  public Image gameMenuImage;

 //   public Toggle BGMToggle;
 //   private AudioSource BGMSource;//MARKER BGM Source
 private string sceneName;
 public GameObject gameMenuImage;
 public void OnPause(){
     Time.timeScale = 0;
     gameMenuImage.SetActive(true);
 }
 public void OnResume(){
     Time.timeScale = 1f;
     gameMenuImage.SetActive(false);
 }
 public void OnRestart() {
     UnityEngine.SceneManagement.SceneManager.LoadScene(0);
     Time.timeScale = 1f;
 }
 public void GoMain(){
     SceneManager.LoadScene("MainScene"); 
     sceneName = SceneManager.GetActiveScene().name;
 }
    
    /*
    public void Resume()
    {
        Debug.Log("RESUME");
        gameMenuImage.gameObject.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.isPaused = false;
    }
    public void Pause()
    {
        Debug.Log("PAUSE");
        gameMenuImage.gameObject.SetActive(true);
        Time.timeScale = 0;
        GameManager.instance.isPaused = true;
    }
    public void BGMToggleButton()
    {
        if(BGMToggle.isOn)
        {
            //OPEN the BGM
            PlayerPrefs.SetInt("BGM", 1);//OPEN
            Debug.Log(PlayerPrefs.GetInt("BGM"));
        }
        else
        {
            //CLOSE the BGM
            PlayerPrefs.SetInt("BGM", 0);//CLOSE
            Debug.Log(PlayerPrefs.GetInt("BGM"));
        }
    }
    private void BGMManager()
    {
        if (PlayerPrefs.GetInt("BGM") == 1)
        {
            BGMToggle.isOn = true;
            BGMSource.enabled = true;
        }
        else if (PlayerPrefs.GetInt("BGM") == 0)
        {
            BGMToggle.isOn = false;
            BGMSource.enabled = false;
        }
    }*/
    void Update()
    {
        
    }
}
