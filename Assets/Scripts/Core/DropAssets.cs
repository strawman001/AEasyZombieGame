using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAssets : MonoBehaviour
{
    public GameObject healingPotion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] DropOutItems(String type)
    {
        return new []{healingPotion};
    }
}
