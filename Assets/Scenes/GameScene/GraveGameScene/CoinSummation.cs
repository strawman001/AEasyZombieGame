using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSummation : MonoBehaviour
{
    public int bank = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnSceneGUI()
    {
        GUI.Label(new Rect(10, 10, 80, 30), "Coins : " + bank);
    }
}
