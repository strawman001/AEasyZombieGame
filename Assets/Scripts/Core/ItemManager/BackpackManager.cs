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
        AddItemToBackpack("3","Item.LifeBond",1);
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

    public void AddItemToBackpack(string fullItemName, int itemNum)
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
            BackpackUI.Instance.ShowConsumableItems();
        }
        else if (item is EquipmentItem)
        {
            equipmentItemList.Add(fullItemName);
            BackpackUI.Instance.ShowEquipmentItems();
        }
        else if (item is WeaponItem)
        {
            weaponItemList.Add(fullItemName);
            BackpackUI.Instance.ShowWeaponItems();
        }
        
    }
    
    
    public void UseOrEquip(string fullItemName)
    {
        BaseItem item = (BaseItem)GameManager.assembly.CreateInstance(fullItemName);
        if (item is ConsumableItem)
        {
            int num = consumableItemDictionary[fullItemName] - 1;
            if (num == 0)
            {
                consumableItemDictionary.Remove(fullItemName);
            }
            else
            {
                consumableItemDictionary[fullItemName] = num;
            }
            ((ConsumableItem)item).Use();
            BackpackUI.Instance.ShowConsumableItems();
        }
        else if (item is EquipmentItem)
        {
            if (EquipmentManager.Instance.EquipEquipemnt(fullItemName,(EquipmentItem)item))
            {
                equipmentItemList.Remove(fullItemName);
                BackpackUI.Instance.ShowEquipmentItems();
            }
        }
        else if (item is WeaponItem)
        {
            if (EquipmentManager.Instance.EquipWeapon(fullItemName,(WeaponItem)item))
            {
                weaponItemList.Remove(fullItemName);
                BackpackUI.Instance.ShowWeaponItems();
            }
        }
    }

    public void DropItem(string fullItemName)
    {
        BaseItem item = (BaseItem) GameManager.assembly.CreateInstance(fullItemName);
        item.DropItem();
        if (item is ConsumableItem)
        {
            consumableItemDictionary.Remove(fullItemName);
            BackpackUI.Instance.ShowConsumableItems();
        }
        else if (item is EquipmentItem)
        {
            equipmentItemList.Remove(fullItemName);
            BackpackUI.Instance.ShowEquipmentItems();
        }
        else if (item is WeaponItem)
        {
            weaponItemList.Remove(fullItemName);
            BackpackUI.Instance.ShowWeaponItems();
        }
    }
    
    
}


