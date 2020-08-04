using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameStoreImage;
    public void OnStore(){
        Time.timeScale = 0;
        gameStoreImage.SetActive(true);
    }
    public void CloseStore(){
        Time.timeScale = 1f;
        gameStoreImage.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
