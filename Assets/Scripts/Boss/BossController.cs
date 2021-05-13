using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossMovementController movementController;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementController.Walk();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
            {
            movementController.Run();
        }
        else
        {
            movementController.Idle();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementController.RotateLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movementController.RotateRight(); 
        }
    }
}
