using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    float speed = 0.0f;
    public float acceleration = 0.2f;
    public float deceleration = 0.5f;
    int speedHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        speedHash = Animator.StringToHash("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        //
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed && speed < 1.0f )
        {
            speed += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && speed > 0.0f )
        {
            speed -= Time.deltaTime * deceleration;
        }

        if (!forwardPressed && speed < 0.0f)
        {
            speed = 0.0f;
        }

        animator.SetFloat(speedHash, speed);
    }
}
