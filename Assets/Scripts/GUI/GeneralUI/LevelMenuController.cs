using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    private GameObject passMenu;
    private GameObject overMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        passMenu = GetComponent<UIComponentManager>().GetUIComponent("Pass");
        overMenu = GetComponent<UIComponentManager>().GetUIComponent("Death");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        //Time.timeScale = 0;
        overMenu.SetActive(true);
    }

    public void LevelPass()
    {
        //Time.timeScale = 0;
        passMenu.SetActive(true);
    }
}
