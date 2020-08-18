
using UnityEngine;

public class PumpkinheadAnimation : MonoBehaviour
{
    Animator Anim;

    void Start()
    {
        Anim = this.GetComponent<Animator>();
    }

    public void Idle()
    {
        Anim.SetInteger("AnimController",0);
    }

    public void Run()
    {
        Anim.SetInteger("AnimController",1);
    }
    public void Attack()
    {
        Anim.SetInteger("AnimController", 2);
    }
    public void HeadButt()
    {
        Anim.SetInteger("AnimController", 3);
    }
    public void Kicking()
    {
        Anim.SetInteger("AnimController", 4);
    }
    public void Punching()
    {
        Anim.SetInteger("AnimController", 5);
    }
    public void GettingHit()
    {
        Anim.SetInteger("AnimController", 6);
    }
    public void Death()
    {
        Anim.SetInteger("AnimController", 7);
    }
}
