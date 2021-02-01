using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGroundCheck : MonoBehaviour
{
    [Header(header: "Gravity - GroundCheck")]
    Vector3 verticalSpeed;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    [Header(header: "REFERENCE")]
    public CharacterController controller;
    public Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && verticalSpeed.y < 0)
        {
            verticalSpeed.y = -2.0f;
        }

        verticalSpeed.y += gravity * Time.deltaTime;
        controller.Move(verticalSpeed * Time.deltaTime);

    }
}
