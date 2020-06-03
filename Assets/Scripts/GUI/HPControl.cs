using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPControl : MonoBehaviour
{
    public Slider HPStrip;
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        HPStrip.value = HPStrip.maxValue = HP ;
    }

    // Update is called once per frame
    public void onHit(int damage)
    {
        HP -= damage;
        HPStrip.value = HP;
    }
}
