using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimyAttack : MonoBehaviour
{

    public float attackTimer = 0.0f;
    public float attackCoolTime = 2.0f;
    public float attackDamage = 20.0f;
    public float attackSpeed = 1.0f;

    //REFERENCE
    public GameObject weapon;



    void Update()
    {

    }

    //Animation Events
    void enableWeapon()
    {
        weapon.GetComponent<Collider>().enabled = true;
    }

    void disableWeapon()
    {
        weapon.GetComponent<Collider>().enabled = false;
    }

}
