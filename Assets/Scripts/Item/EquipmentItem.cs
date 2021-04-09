using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;

public abstract class EquipmentItem : BaseItem
{
    public string equipmentType;
    public abstract void Equip();
    public abstract void Remove();
}
