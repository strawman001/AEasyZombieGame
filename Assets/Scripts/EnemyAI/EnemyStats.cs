using System.Collections;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private AvatarAnimationController animator;
   // public BrainCollection Brain;
    public GameObject healingPotion;
    private void Start()
    {
        animator = GetComponent<AvatarAnimationController>();
    }

    protected override void Die()
    {
       
        
        base.Die();
        animator.HumanDying();
        StartCoroutine(OnEnemyDied());
        
    }

    IEnumerator OnEnemyDied()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        //Drop healing potion
        Instantiate(healingPotion, transform.position, Quaternion.Euler(-90,0,0));
       // Brain.BrainUpdate();
    }
}
