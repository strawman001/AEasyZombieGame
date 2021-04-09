using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance = null;
    private ItemManager(){}
    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {    
                instance = new ItemManager();
            }
            return instance;
        }
    }

    public GameObject backpackManager;

    private void Awake()
    {
        instance = this;
    }

    
    
}
