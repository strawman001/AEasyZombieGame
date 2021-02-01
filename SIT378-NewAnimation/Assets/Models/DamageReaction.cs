using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReaction : MonoBehaviour
{
    Animator animator;
    Collider ObjectCollider;

    public float Health = 100;

    void Start()
    {

        animator = GetComponentInChildren<Animator>();
        ObjectCollider = GetComponent<CapsuleCollider>();

    }

    void Update()
    {
        Death();
    }

    void Death()
    {
        if(Health <= 0)
        {

            animator.SetTrigger("Death");
            ObjectCollider.isTrigger = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<isGroundCheck>().enabled = false;
            ObjectCollider.enabled = false;
        }
    }

     private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Bat")
        {
            Health -= 50;
            Debug.Log("You hurt me!");
            if (Health>0)
            {
                animator.SetTrigger("HitReaction");

            }

        }

    }
   

}
