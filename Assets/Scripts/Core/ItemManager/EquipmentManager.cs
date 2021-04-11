using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Item;
using UnityEngine;
using Object = System.Object;

public class EquipmentManager : MonoBehaviour
{
    private static EquipmentManager instance = null;
    private EquipmentManager(){}
    public static EquipmentManager Instance
    {
        get
        {
            if (instance == null)
            {    
                instance = new EquipmentManager();
            }
            return instance;
        }
    }
    
    private void Awake()
    {
        instance = this;
    }

    private static string headSlot = "";
    private static string bodySlot = "";
    private static string footSlot = "";
    private static string leftHandSlot = "";
    private static string rightHandSlot = "";
    private static string accessorySlot1 = "";
    private static string accessorySlot2 = "";
    private static string accessorySlot3 = "";

    private static Dictionary<string,string> typeSlotDir = new Dictionary<string, string>()
    {
        {"head","headSlot"},
        {"body","bodySlot"},
        {"foot","footSlot"},
        {"leftHand","leftHandSlot"},
        {"rightHand","rightHandSlot"},
        {"accessory","accessorySlot"},
    };

    private void Start()
    {
        
    }

    public static Dictionary<string, string> GetSlotItemDir()
    {
        return new Dictionary<string, string>()
        {
            {"headSlot",headSlot},
            {"bodySlot",bodySlot},
            {"footSlot",footSlot},
            {"leftHandSlot",leftHandSlot},
            {"rightHandSlot",rightHandSlot},
            {"accessorySlot1",accessorySlot1},
            {"accessorySlot2",accessorySlot2},
            {"accessorySlot3",accessorySlot3}
        };
    }
    
    
    public bool EquipEquipemnt(string fullItemName,EquipmentItem equipmentItem)
    {
        string slot = typeSlotDir[equipmentItem.equipmentType];
        if (slot!="accessorySlot")
        {
            if (this.GetType().GetField(slot,BindingFlags.NonPublic|BindingFlags.Static).GetValue(instance)=="")
            {
                this.GetType().GetField(slot,BindingFlags.NonPublic|BindingFlags.Static).SetValue(instance,fullItemName);
                equipmentItem.Equip();
                EquipmentUI.Instance.ShowEquipmentAndWeapon();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if(accessorySlot1=="")
            {
                accessorySlot1 = fullItemName;
                equipmentItem.Equip();
                EquipmentUI.Instance.ShowEquipmentAndWeapon();
                return true;
            }
            else if(accessorySlot2=="")
            {
                accessorySlot2 = fullItemName;
                equipmentItem.Equip();
                EquipmentUI.Instance.ShowEquipmentAndWeapon();
                return true;
            }
            else if(accessorySlot3=="")
            {
                accessorySlot3 = fullItemName;
                equipmentItem.Equip();
                EquipmentUI.Instance.ShowEquipmentAndWeapon();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool EquipWeapon(string fullItemName, WeaponItem weaponItem)
    {
        if (weaponItem.weaponType == "leftHand")
        {
            if (leftHandSlot=="")
            {
                leftHandSlot = fullItemName;
                weaponItem.Equip();
                EquipmentUI.Instance.ShowEquipmentAndWeapon();
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (weaponItem.weaponType == "rightHand")
        {
            if (rightHandSlot=="")
            {
                rightHandSlot = fullItemName;
                weaponItem.Equip();
                EquipmentUI.Instance.ShowEquipmentAndWeapon();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

  
    public void Remove(string fullItemName,string slotName)
    {
        BaseItem item = (BaseItem)GameManager.assembly.CreateInstance(fullItemName);
        if (item is EquipmentItem)
        {
            BackpackManager.Instance.AddItemToBackpack(fullItemName,1);
            ((EquipmentItem)item).Remove();
            this.GetType().GetField(slotName,BindingFlags.NonPublic|BindingFlags.Static).SetValue(instance,"");
            EquipmentUI.Instance.ClearView();
            EquipmentUI.Instance.ShowEquipmentAndWeapon();
        }
        else 
        {
            BackpackManager.Instance.AddItemToBackpack(fullItemName,1);
            ((WeaponItem)item).Remove();
            this.GetType().GetField(slotName,BindingFlags.NonPublic|BindingFlags.Static).SetValue(instance,"");
            EquipmentUI.Instance.ClearView();
            EquipmentUI.Instance.ShowEquipmentAndWeapon();
        }
    }
}
