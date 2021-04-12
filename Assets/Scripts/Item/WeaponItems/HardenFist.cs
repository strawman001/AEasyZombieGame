using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class HardenFist : WeaponItem
    {
        public HardenFist()
        {
            itemName = "HardenFist";
            spritePath = "Sprite/Item/Wool";
            description = "HardenFist: Strength+3";
            weaponType = WeaponType.lefthand;
        }
    
    
        public override void CollectItem()
        {
        
        }

        public override void DropItem()
        {
        
        }

        public override void Equip()
        {
            PlayerProperty playerProperty = PlayerInterface.Instance.GetPlayerProperty();
            playerProperty.STRENGTH += 3;
            playerProperty.ATK = playerProperty.CalATK(playerProperty.STRENGTH);
            playerProperty.CRI_DAMAGE = playerProperty.CalCRI_DAMAGE(playerProperty.EXPLOSION, playerProperty.STRENGTH);
        }

        public override void Remove()
        {
            PlayerProperty playerProperty = PlayerInterface.Instance.GetPlayerProperty();
            playerProperty.STRENGTH -= 3;
            playerProperty.ATK = playerProperty.CalATK(playerProperty.STRENGTH);
            playerProperty.CRI_DAMAGE = playerProperty.CalCRI_DAMAGE(playerProperty.EXPLOSION, playerProperty.STRENGTH);
        }
    }

}
