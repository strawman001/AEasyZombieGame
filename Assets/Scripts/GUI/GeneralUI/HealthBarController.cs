using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider healthBar;
    [SerializeField]
    public Gradient gradient;
    private Image fill;

    private PlayerInterface playerInterface;
    // Start is called before the first frame update
    void Start()
    {
        UIComponentManager uiComponentManager = GetComponent<UIComponentManager>();
        healthBar = uiComponentManager.GetUIComponent("HealthBar").GetComponent<Slider>();
        fill = healthBar.transform.GetChild(0).gameObject.GetComponent<Image>();
        playerInterface = uiComponentManager.GetUIComponent("Player").GetComponent<PlayerInterface>();
        healthBar.maxValue = playerInterface.GetMaxHealth();
        fill.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        int currentHealth = playerInterface.GetCurrentHealth();
        healthBar.value = currentHealth;
        fill.color = gradient.Evaluate((float)currentHealth/(float)healthBar.maxValue);
    }
}
