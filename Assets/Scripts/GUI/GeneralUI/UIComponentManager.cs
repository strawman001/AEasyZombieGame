﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComponentManager : MonoBehaviour
{
    private Dictionary<String, GameObject> uiComponents = new Dictionary<string, GameObject>();
    public GameObject player;
    public GameObject sceneController;
    public GameObject camera1;
    
    private void Awake()
    {
        for (int i=0; i< transform.childCount;i++ )
        {
            Transform child = transform.GetChild(i);
            uiComponents.Add(child.gameObject.name, child.gameObject);
        }
        uiComponents.Add("Player",player);
        uiComponents.Add("SceneController", sceneController);
        uiComponents.Add("Camera",camera1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetUIComponent(String name)
    {
        return uiComponents[name];
    }
    
    
}
