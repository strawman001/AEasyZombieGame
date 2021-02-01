using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitRection : MonoBehaviour
{

    Animator animator;
    Collider ObjectCollider;

    public float Health = 100;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        ObjectCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "AnimyBat")
        {
            Health -= 50;
            Debug.Log("You hurt me!");
            if (Health > 0)
            {
                animator.SetTrigger("HitReaction");
            }
        }
    }


}
