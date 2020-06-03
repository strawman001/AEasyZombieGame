using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BrainCollection : MonoBehaviour
{
    // Start is called before the first frame update
    private int BrainNumber = 88;

  //  private void Start()
  //  {
  //      int BrainNubber = 88;
  //      GetComponent<Text>().text = BrainNumber.ToString();
  //  }

    void Update()
    {
        GetComponent<Text>().text = BrainNumber.ToString();
    }

    // Update is called once per frame
    
}
