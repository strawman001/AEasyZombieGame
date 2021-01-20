using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    private AvatarAnimationController animator;

    public Stat SpecialDamage;

    public Slider Slider;

    public Gradient Gradient;
    
    public GameObject GameDeathImage;
    
    public Image fill;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<AvatarAnimationController>();
        Slider.maxValue = maxHealth;
        fill.color = Color.green;
    }

    private void Update()
    {
        Slider.value = currentHealth;
        
        //if (Slider.normalizedValue <= 0.5f) 
        fill.color = Gradient.Evaluate((float)currentHealth/(float)Slider.maxValue);
    }

    protected override void Die()
    {
        base.Die();

        // Play dead animation.
        animator.ZombieDying();
        
        // Call function to restart the game
        PlayerManager.instance.KillPlayer();
        
        Time.timeScale = 1f;
        GameDeathImage.SetActive(true);
        
    }
}
