using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
  //  public Image gameMenuImage;
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
    void Update()
    {
      
    }
}
