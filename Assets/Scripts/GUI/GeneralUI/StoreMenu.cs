using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameStoreImage;

    private void Start()
    {
        gameStoreImage = GetComponent<UIComponentManager>().GetUIComponent("StoreMenu");
    }

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
