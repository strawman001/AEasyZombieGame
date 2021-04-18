using System;
using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

public abstract class EquipmentItem : BaseItem
{

    public class EquipmentType
    {
        public const string head = "head";
        public const string body = "body";
        public const string foot = "foot";
        public const string accessory = "accessory";
    }
    
    public string equipmentType;
    public abstract void Equip();
    public abstract void Remove();
}
