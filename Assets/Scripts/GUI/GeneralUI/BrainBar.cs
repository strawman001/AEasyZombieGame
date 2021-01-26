using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrainBar : MonoBehaviour
{
    private Text brainNum;

    private int target;
    private int brain;
    // Start is called before the first frame update
    void Start()
    {
        brainNum = GetComponent<UIComponentManager>().GetUIComponent("BrainCollection").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        brainNum.text = GameManager.globalData.brain + "=" + GameManager.globalData.target;
    }

    public void SetBrainData(int target, int brain)
    {
        this.target = target;
        this.brain = brain;
        brainNum.text = brain + "=" + target;
    }
}
