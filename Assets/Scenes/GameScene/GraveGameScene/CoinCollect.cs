using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // Rotates the coin on x-axis
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            // Here we add 1 point to our coin bank and destroy the collected coin
            other.GetComponent<CoinSummation>().bank++;
            Destroy(gameObject);
        }
    }
}
