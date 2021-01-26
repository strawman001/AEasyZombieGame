using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTransfer : MonoBehaviour
{
    private PlayerController playerController;
    private Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<UIComponentManager>().GetUIComponent("Player").GetComponent<PlayerController>();
        joystick = GetComponent<UIComponentManager>().GetUIComponent("Fixed Joystick").GetComponent<Joystick>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerController.SetJoyStick(joystick.Horizontal,joystick.Vertical);
    }
}
