using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{

    public static int level = 0;
    public static int availiablePoints = 5;
    public static int goldCoins = 800;
    
    private void Start()
    {
        level = SceneManager.Instance.levelSceneIndex + 1;
    }
}
