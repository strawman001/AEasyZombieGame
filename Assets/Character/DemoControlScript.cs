using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoControlScript : MonoBehaviour
{
    public AvatarAnimationController controller;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            controller.ZombieIdle();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            controller.ZombieWalk();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            controller.ZombieRun();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            controller.ZombieAttack1();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            controller.ZombieAttack2();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            controller.ZombiePunch();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            controller.ZombieScream();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            controller.ZombieDance();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            controller.ZombieGettingHit();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            controller.ZombieDying();
        }
    }
}
