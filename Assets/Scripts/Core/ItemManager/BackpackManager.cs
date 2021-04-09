using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Item;
using UnityEngine;
using Object = System.Object;

public class BackpackManager : MonoBehaviour
{
    private static BackpackManager instance = null;
    private BackpackManager(){}
    public static BackpackManager Instance
    {
        get
        {
            if (instance == null)
            {    
                instance = new BackpackManager();
            }
            return instance;
        }
    }
    
    private void Awake()
    {
        instance = this;
    }

    private static Dictionary<string, int> consumableItemDictionary = new Dictionary<string, int>();
    private static List<string> equipmentItemList = new List<string>();
    private static List<string> weaponItemList = new List<string>();

    private Assembly assembly;

    private void Start()
    {
        assembly = GameManager.assembly;
    }

    public Dictionary<string, int> GetConsumableItemDictionary()
    {
        return consumableItemDictionary;
    }

    public List<string> GetEquipmentItemList()
    {
        return equipmentItemList;
    }

    public List<string> GetWeaponItemList()
    {
        return weaponItemList;
    }

    public void AddItemToBackpack(string itemID, string fullItemName, int itemNum)
    {
        BaseItem item = (BaseItem) assembly.CreateInstance(fullItemName);
        if (item is ConsumableItem)
        {
            bool isContain = false;
            foreach (KeyValuePair<string,int> pair in consumableItemDictionary)
            {
                if (pair.Key == "Item."+item.itemName)
                {
                    consumableItemDictionary[pair.Key] = pair.Value + itemNum;
                    isContain = true;
                    break;
                }
            }
            if (!isContain)
            {
                Debug.Log(item.itemName);
                consumableItemDictionary.Add(fullItemName,itemNum);
            }
        }
        else if (item is EquipmentItem)
        {
            equipmentItemList.Add(fullItemName);
        }
        else if (item is WeaponItem)
        {
            weaponItemList.Add(fullItemName);
        }
        
        // StringBuilder sb = new StringBuilder();
        // foreach (KeyValuePair<string,int> pair in consumableItemDictionary)
        // {
        //     sb.Append(pair.Key + " : " + pair.Value);
        // }
        // Debug.Log(sb.ToString());

    }
    
    
}


