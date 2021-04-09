using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

public abstract class WeaponItem : BaseItem
{
    public GameObject model;
    public string weaponType;
    public abstract void Equip();
    public abstract void Remove();
}
