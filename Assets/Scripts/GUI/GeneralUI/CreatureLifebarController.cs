using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureLifebarController : MonoBehaviour
{
    public Slider slider;
    
    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
