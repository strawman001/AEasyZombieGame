using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyAttack : MonoBehaviour
{
    public float attackTimer = 0.0f;
    public float attackCoolTime = 2.0f;
    public float attackDamage = 20.0f;
    public float attackSpeed = 1.0f;

    Animator animator;
    public Transform Player;
    public CharacterController controller;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void enableWeapon()
    {
        weapon.GetComponent<Collider>().enabled = true;
    }

    void disableWeapon()
    {
        weapon.GetComponent<Collider>().enabled = false;
    }



}
