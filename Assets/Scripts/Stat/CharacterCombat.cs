using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    private float attackDelay = .6f;
    
    private CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(Stat damage, CharacterStats target)
    {
        if (attackCooldown < 0)
        {
            StartCoroutine(DoDamage(damage, target, attackDelay));
            attackCooldown = 1f / attackSpeed; 
        }
    }

    IEnumerator DoDamage(Stat damage, CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        
        stats.TakeDamage(damage.GetValue());
    }
}
