using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BrainCollection : MonoBehaviour
{
    // Start is called before the first frame update
    private int brainNumber;
    private int target = 2;
    //public GameObject Brain;
    public GameObject gamePassImage;
    public void Start()
  {
      brainNumber = 0;
      GetComponent<Text>().text = brainNumber +" = " + target;
      
  }
  //   public void Update()
  // { 
  // }
  public void BrainUpdate()
  {
      if (brainNumber < (target - 1)){
          brainNumber = brainNumber + 1;
          GetComponent<Text>().text = brainNumber + " = " + target;
      }
      else
      {
          GetComponent<Text>().text =  target + " = " + target;
          Time.timeScale = 1f;
          gamePassImage.SetActive(true);
      }

  }
    
}
