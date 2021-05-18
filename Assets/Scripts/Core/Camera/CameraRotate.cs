using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private GameObject focusPoint;
    private float rotationSpeed = 1.0f;
    private bool rotationFlag = false;
    private int direction = 1;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        focusPoint = transform.parent.transform.gameObject;
        playerController = focusPoint.GetComponent<FollowPlayer>().player.GetComponent<PlayerController>();
        playerController.SetViewDirection(transform.rotation.eulerAngles.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationFlag)
        {
            RotateCamera();
            playerController.SetViewDirection(transform.rotation.eulerAngles.y);
        }
    }

    //right -1 left 1
    private void RotateCamera()
    {
        transform.RotateAround(focusPoint.transform.position,Vector3.up, rotationSpeed*direction);
    }

    public void RotateBeigin(int direction)
    {
        this.direction = direction;
        rotationFlag = true;
    }

    public void RotateEnd()
    {
        rotationFlag = false;
    }
    
    
}
