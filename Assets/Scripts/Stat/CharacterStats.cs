using UnityEngine;
using UnityEngine.UIElements;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    
    [SerializeField] public int currentHealth { get; set; }

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Damage taken is lesser with armor.
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // Subtract damage from current health.
        currentHealth -= damage;

        // Check if character is out of health.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Overwritten for enemy and player.
        Debug.Log("Die");
    }
}
