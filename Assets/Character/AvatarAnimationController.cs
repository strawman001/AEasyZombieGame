

// moving and attacking cannot be done in the same time
// pause movement when using attack animation



using UnityEngine;

public class AvatarAnimationController : MonoBehaviour
{
    public Animator animatorController;
    public bool isZombie; //if avatar is zombie, set true
    

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
    }

    public void ZombieAttack1()
    {
        //one time animation call, returns to idle animation
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType" , 0);
    }
    public void ZombieAttack2()
    {
        //one time animation call, returns to idle animation
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType", 1);
    }
    public void ZombiePunch()
    {
        //one time animation call, returns to idle animation
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType", 2);
    }

    public void ZombieScream()
    {
        //one time animation call, returns to idle animation
        //can only been called after Zombie Idle
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 3);
        animatorController.SetInteger("AnimSubType", 0);
    }
    public void ZombieDance()
    {
        //loops
        //can only been called after Zombie Idle
        animatorController.SetTrigger("Attack");
        animatorController.SetInteger("AnimType", 3);
        animatorController.SetInteger("AnimSubType", 1);
    }
    public void ZombieWalk()
    {
        //loops
        animatorController.SetInteger("AnimType", 1);
        animatorController.SetInteger("AnimSubType", 0);
    }

    public void ZombieRun()
    {
        //loops
        animatorController.SetInteger("AnimType", 1);
        animatorController.SetInteger("AnimSubType", 1);
    }

    public void ZombieGettingHit()
    {
        //one time animation call, returns to idle animation
        animatorController.SetInteger("AnimType", 4);
        animatorController.SetInteger("AnimSubType", 0);
    }
    public void ZombieDying()
    {
        //one time animation call, returns to idle animation
        animatorController.SetInteger("AnimType", 4);
        animatorController.SetInteger("AnimSubType", 1);
    }

    public void HumanWalk()
    {
        //loops
        animatorController.SetInteger("AnimType", 1);
        animatorController.SetInteger("AnimSubType", 0);
    }
    public void HumanRun()
    {
        //loops
        animatorController.SetInteger("AnimType", 1);
        animatorController.SetInteger("AnimSubType", 1);
    }

    public void HumanIdle()
    {
        //loops
        animatorController.SetInteger("AnimType", 0);
    }

    public void HumanShootGun1()
    {
        //one time animation call, returns to idle animation
        animatorController.SetInteger("AnimType", 2);
        animatorController.SetInteger("AnimSubType", 0);
        animatorController.SetTrigger("Attack");
    }

    public void HumanDying()
    {
        animatorController.SetInteger("AnimType", 4);
    }
}
 