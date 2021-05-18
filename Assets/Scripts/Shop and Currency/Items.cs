using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items 
{
    //These enums are the different types of items we have
    //Can easily add whatever we need here but have these two for testing
    public enum ItemType {
        Brains,
        HealthPotion
        
    }

    public static int GetCost(ItemType itemType){               //This gives each item type a specific gold amount
        switch(itemType){
            default:
            case ItemType.Brains:           return 5;
            case ItemType.HealthPotion:     return 10;
        }
    }



    public static Sprite GetSprite(ItemType itemType){          //This uses the GameAssets to give the items their display image
        switch(itemType){
            default:
            case ItemType.Brains:           return GameAssets.i.Brain;
            case ItemType.HealthPotion:     return GameAssets.i.HealingPotion;
        }
    }
}
