using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<UIComponentManager>().GetUIComponent("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BasicAttack()
    {
        playerController.BasicAttack();
    }

    public void SpecialAttack()
    {
        playerController.SpecialAttack();
    }
}
