using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotionController : MonoBehaviour
{
    public int healingValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 30.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag=="Player")
        {
            GameObject player = other.gameObject;
            CharacterStats playerStats = player.GetComponent<CharacterStats>();
            if (playerStats.currentHealth+healingValue>playerStats.maxHealth)
            {
                playerStats.currentHealth = playerStats.maxHealth;
            }
            else
            {
                playerStats.currentHealth += healingValue;
            }

            //Debug.Log("Current Health = 50");
            Destroy(gameObject);
        }
    }
}
