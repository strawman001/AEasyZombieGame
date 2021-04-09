﻿using System.Collections;
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

    public int GetPhysicAttackValue()
    {
        return playerProperty.physicalAttack;
    }

    public int GetCurrentHealth()
    {
        return playerProperty.currentHealth;
    }

    public void ChangeCurrentHealth(int value)
    {
        SetCurrentHealth(playerProperty.currentHealth+= value); 
    }

    public void SetCurrentHealth(int currentHealth)
    {
        if (currentHealth > playerProperty.maxHealth)
        {
            playerProperty.currentHealth = playerProperty.maxHealth;
        }
        else if (currentHealth < 0)
        {
            playerProperty.currentHealth = 0;
            Die();
        }
    }

    public int GetMaxHealth()
    {
        return playerProperty.maxHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        playerProperty.maxHealth = maxHealth;
    }

    public override void ReceiveDamage(int damage)
    {
        ChangeCurrentHealth(-damage);
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
