using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimyController : MonoBehaviour
{
    Animator animator;
    Collider ObjectCollider;
    private Collider[] colliders;
        private Rigidbody[] rigidbodys;
    public float Health = 100;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        ObjectCollider = GetComponent<CapsuleCollider>();

        setRigidbodyState(false);
        setColliderState(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bat")
        {
            Health -= 50;
            Debug.Log("You hurt me!");
            if (Health > 0)
            {
                animator.SetTrigger("HitReaction");
            }
        }
    }

    void die()
    {

    }

    void setRigidbodyState(bool state)
    {
        Rigidbody [] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }
       // GetComponent<Rigidbody>().isKinematic = !state;

    }

    void setColliderState(bool state)
    {
        Collider [] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
        GetComponent<CapsuleCollider>().enabled = !state;
    }

}
