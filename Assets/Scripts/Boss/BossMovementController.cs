using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Animator))]
public class BossMovementController : MonoBehaviour
{
    public Animator BossAnimator;
    public Rigidbody bossrigidbody;


    private void Start()
    {
        if (BossAnimator == null)
        {
            BossAnimator = this.gameObject.GetComponent<Animator>();
        }

        if (bossrigidbody == null)
        {
            bossrigidbody = this.gameObject.GetComponent<Rigidbody>();

        }
    }
    public void Idle()
    {
        BossAnimator.SetInteger("Boss Control", 0);
    }

    public void Rotate(float value)
    {
        this.transform.Rotate(new Vector3(0, value * Time.deltaTime, 0));
    }

    public void RotateLeft()
    {
        this.transform.Rotate(new Vector3(0, -100.0f * Time.deltaTime, 0));
    }

    public void RotateRight()
    {
        this.transform.Rotate(new Vector3(0, 100.0f * Time.deltaTime, 0));
    }

    public void Walk()
    {
        BossAnimator.SetInteger("Boss Control", 1);
        transform.Translate(Vector3.forward * Time.deltaTime * 2.0f);
    }

    public void Run()
    {
        BossAnimator.SetInteger("Boss Control", 2);
        transform.Translate(Vector3.forward * Time.deltaTime * 10.0f);
    }

    public void MeleeAttack()
    {
        BossAnimator.SetTrigger("Melee");
    }

    public void ShootGun()
    {

        BossAnimator.SetTrigger("ShootGun");
    }

    public void Die()
    {

        BossAnimator.SetTrigger("Death");
    }
}
