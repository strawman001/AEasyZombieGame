using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoControlScript : MonoBehaviour
{
    public AvatarAnimationController controller;
    public AvatarAnimationController controller2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            controller.ZombieIdle();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            controller.ZombieWalk();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            controller.ZombieRun();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            controller.ZombieAttack1();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            controller.ZombieAttack2();
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            controller.ZombiePunch();
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            controller.ZombieScream();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            controller.ZombieDance();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            controller.ZombieGettingHit();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            controller.ZombieDying();
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            controller2.HumanIdle();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            controller2.HumanWalk();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            controller2.HumanRun();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            controller2.HumanShootGun1();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            controller2.HumanPunching();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            controller2.HumanKicking();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            controller2.HumanMelee();
        }

    }
}
