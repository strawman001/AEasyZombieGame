using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    // Coins have been given tag of "Coin" 
    // Updates number of coins, when player makes contact with tagged Coin it is destroyed
    // Prints out to the UI the total Coins
    
    public static CoinCounter Instance {get; private set;}
    public static int coins = 0;
    public Text txt;

    private void Awake(){
        Instance = this;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Coin" )
            coins++;
            
            
    }
    void Update()
    {
        txt.GetComponent<UnityEngine.UI.Text>().text = coins.ToString();
    } 

    


}
