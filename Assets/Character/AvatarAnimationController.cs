

// moving and attacking cannot be done in the same time
// pause movement when using attack animation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAnimationController : MonoBehaviour
{
    public Animator animatorController;
    public bool isZombie; //if avatar is zombie, set true

    [Header("Sound Effects")]
    public AudioSource audioSource;
    public AudioClip audioClip_Idle;
    public AudioClip audioClip_Running;
    public AudioClip audioClip_ZombieWalking;
    public AudioClip audioClip_ZombieScream;
    public AudioClip audioClip_meleeAttack;
    public AudioClip audioClip_punching;
    public AudioClip audioClip_Gunshot;



    private void Start()
    {
        if (isZombie == true)
        {
            animatorController.SetBool("IsZombie", true);
        }

        else
        {
            animatorController.SetBool("IsZombie", false);
        }
    }
    public void ZombieIdle()
    {
        //loops
        animatorController.SetInteger("AnimType", 0);
        audioSource.loop = true;
        audioSource.clip = audioClip_Idle;
        audioSource.Play();
    }

    public void ZombieAttack1()
    {
        //one time animation call, returns to idle animation
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType" , 0);
        audioSource.loop = false;
        audioSource.clip = audioClip_punching;
        audioSource.Play();
    }
    public void ZombieAttack2()
    {
        //one time animation call, returns to idle animation
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType", 1);
        audioSource.loop = false;
        audioSource.clip = audioClip_punching;
        audioSource.Play();
    }
    public void ZombiePunch()
    {
        //one time animation call, returns to idle animation
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType", 2);
        audioSource.loop = false;
        audioSource.clip = audioClip_punching;
        audioSource.Play();
    }

    public void ZombieScream()
    {
        //one time animation call, returns to idle animation
        //can only been called after Zombie Idle
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 3);
        animatorController.SetInteger("AnimSubType", 0);
        audioSource.loop = false;
        audioSource.clip = audioClip_ZombieScream;
        audioSource.Play();
    }
    public void ZombieDance()
    {
        //loops
        //can only been called after Zombie Idle
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 3);
        animatorController.SetInteger("AnimSubType", 1);
        audioSource.loop = true;
    }
    public void ZombieWalk()
    {
        //loops
        animatorController.SetInteger("AnimType", 1);
        animatorController.SetInteger("AnimSubType", 0);
        audioSource.loop = true; 
        audioSource.clip = audioClip_ZombieWalking;
        audioSource.Play();
    }

    public void ZombieRun()
    {
        //loops
        animatorController.SetInteger("AnimType", 1);
        animatorController.SetInteger("AnimSubType", 1);
        audioSource.loop = true;
        audioSource.clip = audioClip_Running;
        audioSource.Play();
    }

    public void ZombieGettingHit()
    {
        //one time animation call, returns to idle animation
        animatorController.SetInteger("AnimType", 4);
        animatorController.SetInteger("AnimSubType", 0);
        audioSource.loop = false;
    }
    public void ZombieDying()
    {
        //one time animation call, returns to idle animation
        animatorController.SetInteger("AnimType", 4);
        animatorController.SetInteger("AnimSubType", 1);
        audioSource.loop = false;
    }

    public void HumanWalk()
    {
        //loops
        animatorController.SetInteger("AnimType", 1);
        animatorController.SetInteger("AnimSubType", 0);
        audioSource.loop = true;
    }
    public void HumanRun()
    {
        //loops
        animatorController.SetInteger("AnimType", 1);
        animatorController.SetInteger("AnimSubType", 1);
        audioSource.loop = true;
        audioSource.clip = audioClip_Running;
        audioSource.Play();
    }

    public void HumanIdle()
    {
        //loops
        animatorController.SetInteger("AnimType", 0);
        audioSource.loop = true;
        audioSource.clip = audioClip_Idle;
        audioSource.Play();
    }

    public void HumanShootGun1()
    {
        //one time animation call, returns to idle animation
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType", 0);
        animatorController.SetTrigger("Attack");
        audioSource.loop = false;
        audioSource.clip = audioClip_Gunshot;
        audioSource.Play();
    }
    public void HumanKicking()
    {
        //one time animation call, returns to idle animation
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType", 1);
        animatorController.SetTrigger("Attack");
        audioSource.loop = false;
        audioSource.clip = audioClip_punching;
        audioSource.Play();
    }

    public void HumanPunching()
    {
        //one time animation call, returns to idle animation
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType", 2);
        animatorController.SetTrigger("Attack");
        audioSource.loop = false;
        audioSource.clip = audioClip_punching;
        audioSource.Play();
    }

    public void HumanMelee()
    {
        //one time animation call, returns to idle animation
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType", 3);
        animatorController.SetTrigger("Attack");
        audioSource.loop = false;
        audioSource.clip = audioClip_meleeAttack;
        audioSource.Play();
    }
    public void HumanDying()
    {
        animatorController.SetInteger("AnimType", 4);
        audioSource.loop = false;
    }
}
 