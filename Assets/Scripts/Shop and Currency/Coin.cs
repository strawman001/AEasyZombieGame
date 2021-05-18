using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    // These allow you to change the roation while in the editor
    [SerializeField] float xAngle = 0; 
    [SerializeField] float yAngle = 0;
    [SerializeField] float zAngle = 0;
 
    
    // Used to rotate the coins
    void Update()
    {
        transform.Rotate(xAngle,yAngle,zAngle);
    } 

    // Destroys the coin when the player makes contact
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
        
    }

}