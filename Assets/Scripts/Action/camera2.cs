using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2 : MonoBehaviour
{
    private Transform player;
    private Vector3 offsetPosition;
    private float distance;
    private float scrollSpeed = 10; //Mouse wheel speed
    private bool isRotating; //Turn on camera rotation
    private float rotateSpeed = 2; //Camera rotation speed
    //all these number can be changed!
    private float speed = 10;
    private float endZ = -8;
    private Camera came;
    // Use this for initialization

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Remember add tag to model, name can be changed but also need to change the code.
        came = this.GetComponent<Camera>();
    }
    void Start()
    {
        transform.LookAt(player.position);
        //Get the position offset of the camera and player
        offsetPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = offsetPosition + player.position;
        //The camera follows the player and keeps the relative position offset of the player        
        ScrollView();
        //Camera field of view control      
        RotateView();
        //Camera rotation
    }

    void ScrollView()
    {
        //zoom in
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (came.fieldOfView <= 70)
            {
                came.fieldOfView += 5;
            }
        }
        //zoom out
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (came.fieldOfView >= 30)
            {
                came.fieldOfView -= 5;
            }
        }
    }
    void RotateView()
    {
        //Get the mouse sliding in the horizontal direction
        Debug.Log(Input.GetAxis("Mouse X"));
        //Get the mouse sliding in the vertical direction
        Debug.Log(Input.GetAxis("Mouse Y"));
        //Press the right mouse button to turn on the rotating camera
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        //Raise the right mouse button to turn off the rotating camera
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }
        if (isRotating)
        {
            //initial position
            Vector3 pos = transform.position;
            //Initial angle
            Quaternion rot = transform.rotation;
            //The camera rotates around the player's position along the player's Y axis, and the rotation speed is the horizontal sliding speed of the mouse
            transform.RotateAround(player.position, player.up, Input.GetAxis("Mouse X") * rotateSpeed);
            //Same just change the x.
            transform.RotateAround(player.position, transform.right, Input.GetAxis("Mouse Y") * rotateSpeed);
            //Get the Euler angle of the camera x axis
            float x = transform.eulerAngles.x;
            //Restricted scope
            if (x < 10 || x > 80)
            {
                transform.position = pos;
                transform.rotation = rot;
            }
        }
        //update
        offsetPosition = transform.position - player.position;
    }
}