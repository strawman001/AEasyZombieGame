using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    /*The Game assets is given to an empty prefab within the Resources folder
    This is where we keep track of any needed game icons(sprites)
    Simply add a new public Sprite and a name
    Then go find the GameAssets prefab in the game editor and pick which sprite is needed
    */
    private static GameAssets _i;

    public static GameAssets i{
        get{
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    public Sprite Brain;
    public Sprite HealingPotion;
}
