using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    private static CanvasUI instance = null;
    private CanvasUI(){}
    public static CanvasUI Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public GameObject GetCanvasUI()
    {
        return transform.gameObject;
    }
}
