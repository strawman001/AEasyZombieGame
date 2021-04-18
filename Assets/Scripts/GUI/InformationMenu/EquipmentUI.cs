using System;
using System.Collections;
using System.Collections.Generic;
using Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour,IPointerClickHandler
{
    private static EquipmentUI instance = null;
    private EquipmentUI(){}
    public static EquipmentUI Instance
    {
        get
        {
            if (instance == null)
            {    
                instance = new EquipmentUI();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> slotObjectList;
    private Dictionary<string,GameObject> slotObjectDir = new Dictionary<string, GameObject>();
    public GameObject itemIcon;

    public GameObject equipmentMenu;
    public GameObject equipmentDescriptionPanel;
    private GameObject target = null;
    private Vector3 targetPosition;
    private String targetSlotName = "";
    
    private void Start()
    {
        foreach (GameObject slot in slotObjectList)
        {
            slotObjectDir.Add(slot.name,slot);
        }
        
    }

    public void ClearView()
    {
        foreach (GameObject slot in slotObjectList)
        {
            if (slot.transform.childCount>0)
            {
                Destroy(slot.transform.GetChild(0).gameObject);
            }
        }
    }
    
    public void ShowEquipmentAndWeapon()
    {
        ClearView();
        Dictionary<string, string> slotItemsDir = EquipmentManager.GetSlotItemDir();
        foreach (KeyValuePair<string,string> pair in slotItemsDir)
        {
            if (pair.Value!="")
            {
                BaseItem item = (BaseItem) GameManager.assembly.CreateInstance(pair.Value);
                GameObject newItemIcon = AssembleGrid(item.spritePath);
                newItemIcon.name = "ItemIcon";
                newItemIcon.tag = pair.Value;
                newItemIcon.transform.parent = slotObjectDir[pair.Key].transform;
                newItemIcon.transform.GetComponent<RectTransform>().anchoredPosition3D =new Vector3(0, 0, 0);
            }
        }
    }
    
    private GameObject AssembleGrid(string spriteIconPath)
    {
        GameObject newItemIcon = Instantiate(itemIcon);
        Sprite icon = Resources.Load<Sprite>(spriteIconPath);
        newItemIcon.GetComponent<Image>().overrideSprite = icon;
        
        return newItemIcon;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        equipmentMenu.SetActive(false);
        equipmentDescriptionPanel.SetActive(false);
        target = null;
        targetSlotName = "";
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == "ItemIcon")
            {
                target = result.gameObject;
                targetPosition = new Vector3(eventData.position.x,eventData.position.y,0);
                targetSlotName = result.gameObject.transform.parent.gameObject.name;
                equipmentMenu.transform.position = new Vector3(eventData.position.x+65,eventData.position.y-50,0);
                equipmentMenu.SetActive(true);
                break;
            }
        }
    }
    
    public void ShowDescription()
    {
        equipmentMenu.SetActive(false);
        if (target!=null)
        {
            String fullItemName = target.tag;
            BaseItem item = (BaseItem)GameManager.assembly.CreateInstance(fullItemName);
            equipmentDescriptionPanel.transform.position = new Vector3(targetPosition.x+70, targetPosition.y-90, 0);
            (equipmentDescriptionPanel.transform.GetChild(0).gameObject.GetComponent<Text>()).text = item.description;
            equipmentDescriptionPanel.SetActive(true);
        }
    }
    
    public void Remove()
    {
        equipmentMenu.SetActive(false);
        if (target != null)
        {
            String fullItemName = target.tag;
            EquipmentManager.Instance.Remove(fullItemName,targetSlotName);
          
        }
    }
}
