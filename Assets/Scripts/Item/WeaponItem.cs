using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

public abstract class WeaponItem : BaseItem
{
    class WeaponType
    {
        public const string lefthand = "lefthand";
        public const string rightHand = "rightHand";
    }
    
    
    public GameObject model;
    public string weaponType;
    public abstract void Equip();
    public abstract void Remove();
}
