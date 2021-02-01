using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{

    Animator animator;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
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

    void enableCollider()
    {
        GetComponentInParent<CapsuleCollider>().enabled = true;
    }

    void disableCollider()
    {
        GetComponentInParent<CapsuleCollider>().enabled = false;
    }

}
