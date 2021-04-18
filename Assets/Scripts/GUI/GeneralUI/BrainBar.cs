using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrainBar : MonoBehaviour
{
    private static BrainBar instance = null;
    private BrainBar(){}
    public static BrainBar Instance
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


    private Text brainNum;
    private int target;
    private int brain;
    // Start is called before the first frame update
    void Start()
    {
        brainNum = GetComponent<UIComponentManager>().GetUIComponent("BrainCollection").GetComponent<Text>();
        UpdateBrainNum();
    }

    // Update is called once per frame
    public void UpdateBrainNum()
    {
        brainNum.text = GameManager.Instance.levelData.currentBrainNum + "=" + GameManager.Instance.levelData.targetBrainNum;
    }
    
}
