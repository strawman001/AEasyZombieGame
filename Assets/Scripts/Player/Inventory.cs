using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private int slots = 5;

    #region Singleton
    
    public static Inventory instance;

    public void Awake()
    {
        if (instance != null)
            return;
        
        instance = this;
    }
    
    #endregion

    public void Add(Item item)
    {
        if (items.Count < slots || PlayerManager.instance.brains < item.cost)
            items.Add(item);
    }

    public void Remove(Item item)
    {
        if (!item.isDefaultItem)
            items.Remove(item);
    }
} 
