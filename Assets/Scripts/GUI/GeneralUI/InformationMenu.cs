using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameInformationImage;

    private void Start()
    {
        gameInformationImage = GetComponent<UIComponentManager>().GetUIComponent("InformationMenu");
    }

    public void OnInformation(){
        Time.timeScale = 0;
        BackpackUI.Instance.ShowConsumableItems();
        EquipmentUI.Instance.ShowEquipmentAndWeapon();
        AttributeUI.Instance.ShowProperty();
        gameInformationImage.GetComponent<CanvasGroup>().alpha = 1;
        gameInformationImage.GetComponent<CanvasGroup>().interactable = true;
        gameInformationImage.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void CloseInformation(){
        Time.timeScale = 1f;
        gameInformationImage.GetComponent<CanvasGroup>().alpha = 0;
        gameInformationImage.GetComponent<CanvasGroup>().interactable = false;
        gameInformationImage.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    void Update()
    {
        
    }
}
