using UnityEngine;

namespace Item
{
    public class LifeBond : EquipmentItem
    {
        public LifeBond()
        {
            itemName = "LifeBond";
            spritePath = "Sprite/Item/Fabric";
            description = "Life Bond: borrow life and remember to pay the debt. When equip HP+30, When remove HP-30";
            equipmentType = EquipmentType.accessory;

        }
        public override void CollectItem(){}

        public override void DropItem(){}

        public override void Equip()
        {
            PlayerInterface.Instance.ChangeCurrentHealth(30);
        }

        public override void Remove()
        {
            PlayerInterface.Instance.ChangeCurrentHealth(-30);
        }
    }
}
