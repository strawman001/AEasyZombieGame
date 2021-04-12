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
 private SceneManager sceneManager;
 private AudioSource audioSource;
 private bool auidoSourceTrigger = true;
 private Slider bgmSlider;
 private void Start()
 {
     gameMenuImage = GetComponent<UIComponentManager>().GetUIComponent("GameMenu");
     sceneManager = GetComponent<UIComponentManager>().GetUIComponent("SceneManager").GetComponent<SceneManager>();
     audioSource = GetComponent<UIComponentManager>().GetUIComponent("Camera").GetComponent<AudioSource>();
     bgmSlider = GetComponent<UIComponentManager>().GetUIComponent("GameMenu").transform.GetChild(3).GetComponent<Slider>();
 }


 public void OnPause(){
     Time.timeScale = 0;
     gameMenuImage.GetComponent<CanvasGroup>().alpha = 1;
     gameMenuImage.GetComponent<CanvasGroup>().interactable = true;
     gameMenuImage.GetComponent<CanvasGroup>().blocksRaycasts = true;
 }
 public void OnResume(){
     Time.timeScale = 1f;
     gameMenuImage.GetComponent<CanvasGroup>().alpha = 0;
     gameMenuImage.GetComponent<CanvasGroup>().interactable = false;
     gameMenuImage.GetComponent<CanvasGroup>().blocksRaycasts = false;
 }
 public void OnRestart() {
     UnityEngine.SceneManagement.SceneManager.LoadScene(0);
     Time.timeScale = 1f;
 }
 public void QuitGame() {
     Time.timeScale = 1f;
     sceneManager.GoMainScene();
 }
 
 public void OnChangeVol()
 {
     if (audioSource!=null)
     {
         audioSource.volume = bgmSlider.value;
     }
     
 }

 public void TriggerAudio()
 {
     auidoSourceTrigger = !auidoSourceTrigger;
     if (audioSource!=null)
     {
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
}
