using System;
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
 private GameObject gameMenuImage;
 private SceneController sceneController;
 private AudioSource audioSource;
 private bool auidoSourceTrigger = true;
 private Slider bgmSlider;
 private void Start()
 {
     gameMenuImage = GetComponent<UIComponentManager>().GetUIComponent("GameMenu");
     sceneController = GetComponent<UIComponentManager>().GetUIComponent("SceneController").GetComponent<SceneController>();
     audioSource = GetComponent<UIComponentManager>().GetUIComponent("Camera").GetComponent<AudioSource>();
     bgmSlider = GetComponent<UIComponentManager>().GetUIComponent("GameMenu").transform.GetChild(2).GetComponent<Slider>();
 }


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
 public void QuitGame() {
     Time.timeScale = 1f;
     sceneController.GoMainScene();
 }
 
 public void OnChangeVol()
 {
     audioSource.volume = bgmSlider.value;
 }

 public void TriggerAudio()
 {
     auidoSourceTrigger = !auidoSourceTrigger;
     if (auidoSourceTrigger)
     {
         audioSource.Play();
     }
     else
     {
         audioSource.Pause();
     }
 }
}
