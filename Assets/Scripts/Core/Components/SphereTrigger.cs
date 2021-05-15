using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    public float radis = 25.0f;

    private Action triggerEnterMethod;
    private Action triggerExitMethod;

    private void Start()
    {
        GetComponent<SphereCollider>().radius = radis;
    }

    public void SetTriggerEnter(Action action)
    {
        triggerEnterMethod = action;
    }

    public void SetTriggerExit(Action action)
    {
        triggerExitMethod = action;
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterMethod?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitMethod?.Invoke();
    }
}
