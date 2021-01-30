using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Animator animator;
    public float playerSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame 
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(horizontal, 0.0f, vertical);

        if( dir != Vector3.zero)
        {
            // Player rotartion
            transform.rotation = Quaternion.LookRotation(dir);

            //Player moving speed 
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);

            //Animation change --- idle to run
            animator.SetBool("Run", true);

        }else{

            //Animation change --- run to idle
            animator.SetBool("Run", false);
        }
    }
}
