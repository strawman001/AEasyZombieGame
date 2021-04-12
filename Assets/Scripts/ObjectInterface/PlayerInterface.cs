using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerInterface : BioInterface
{
    private static PlayerInterface instance = null;
    private PlayerInterface(){}
    public static PlayerInterface Instance
    {
        get
        {
            if (instance == null)
            {    
                instance = new PlayerInterface();
            }
            return instance;
        }
    }
    
    // Start is called before the first frame update
  
    private PlayerProperty playerProperty;
    private Animator animationController;
    
    void Awake()
    {
        instance = this;
        
        playerProperty = GetComponent<PlayerProperty>();
        animationController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerProperty GetPlayerProperty()
    {
        return playerProperty;
    }
    
    public int GetGeneralAttackValue()
    {
        return playerProperty.GetGeneralAttackValue();
    }

    public int GetCurrentHealth()
    {
        return playerProperty.CURRENT_HP;
    }

    public void ChangeCurrentHealth(int value)
    {
        SetCurrentHealth(playerProperty.CURRENT_HP+= value); 
    }

    public void SetCurrentHealth(int currentHealth)
    {
        if (currentHealth > playerProperty.MAX_HP)
        {
            playerProperty.CURRENT_HP = playerProperty.MAX_HP;
        }
        else if (currentHealth < 0)
        {
            playerProperty.CURRENT_HP = 0;
            Die();
        }
    }

    public int GetMaxHealth()
    {
        return playerProperty.MAX_HP;
    }

    public void SetMaxHealth(int maxHealth)
    {
        playerProperty.MAX_HP = maxHealth;
    }

    public override void ReceiveGeneralDamage(int damage)
    {
        Debug.Log("Init Damage:" + damage);
        Debug.Log(playerProperty.GetGeneralDamage(damage));
        ChangeCurrentHealth(-playerProperty.GetGeneralDamage(damage));
    }

    public override void ReceiveAbilityDamage(int damage)
    {
        ChangeCurrentHealth(-playerProperty.GetAbilityDamage(damage));
    }

    public override void Die()
    { 
        animationController.SetTrigger("Death");
        GameManager.AddMessage("GameOver");
    }

    public Animator GetAnimator()
    {
        return animationController;
    }
    
}
