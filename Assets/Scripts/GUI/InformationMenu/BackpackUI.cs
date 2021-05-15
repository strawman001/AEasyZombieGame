using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackpackUI : MonoBehaviour,IPointerClickHandler
{
    private static BackpackUI instance = null;
    private BackpackUI(){}
    public static BackpackUI Instance
    {
        get
        {
            if (instance == null)
            {    
                instance = new BackpackUI();
            }
            return instance;
        }
    }
    
    
    public GameObject slotPanel;
    public GameObject backpackMenu;
    public GameObject backpackDescriptionPanel;
    public List<GameObject> slotList;
    public int status = 1;//1 means consumableItems 2 for equipment 3 for weapon; 
    
    private GameObject itemIcon;
    private Assembly assembly;
    private GameObject target = null;
    private Vector3 targetPosition;
    
    private Dictionary<string,int> consumableItems = BackpackManager.Instance.GetConsumableItemDictionary();
    private List<string> equipmentItems = BackpackManager.Instance.GetEquipmentItemList();
    private List<string> weaponItems = BackpackManager.Instance.GetWeaponItemList();
    
    private void Awake()
    {
        instance = this;
        Transform slotPanelTransform = transform.GetChild(1);
        for (int i=0; i< slotPanelTransform.childCount;i++ )
        {
            Transform child = slotPanelTransform.GetChild(i);
            slotList.Add(child.gameObject);
        }
        
    }

    private void Start()
    {
        itemIcon = Resources.Load("Prefab/UI/ItemIcon") as GameObject;
        assembly = GameManager.assembly;

    }

    private void Update()
    {
        
    }


    //TDOO Need to stop backpack overfill
    public void ShowConsumableItems()
    {
        ClearView();
        status = 1;
        int i = 0;
        foreach (KeyValuePair<string,int> pair in consumableItems)
        {
            //ConsumableItem item = (ConsumableItem)_assembly.CreateInstance("Item." + pair.Key);
            ConsumableItem item =  (ConsumableItem)assembly.CreateInstance(pair.Key);
            GameObject newItemIcon = AssembleGrid(item.spritePath, pair.Value);
            newItemIcon.name = "ItemIcon";
            newItemIcon.tag = pair.Key;
            newItemIcon.transform.parent = slotList[i].transform;
            newItemIcon.transform.GetComponent<RectTransform>().anchoredPosition3D =new Vector3(0, 0, 0);
            i++;
        }
    }

    public void ShowEquipmentItems()
    {
        ClearView();
        status = 2;
        int i = 0;
        foreach (string fullItemName in equipmentItems)
        {
            EquipmentItem item = (EquipmentItem) assembly.CreateInstance(fullItemName);
            GameObject newItemIcon = AssembleGrid(item.spritePath, 0);
            newItemIcon.name = "ItemIcon";
            newItemIcon.tag = fullItemName;
            newItemIcon.transform.parent = slotList[i].transform;
            newItemIcon.transform.GetComponent<RectTransform>().anchoredPosition3D =new Vector3(0, 0, 0);
            i++;
        }
        
    }

    public void ShowWeaponItems()
    {
        ClearView();
        status = 3;
        int i = 0;
        foreach (string fullItemName in weaponItems)
        {
            WeaponItem item = (WeaponItem) assembly.CreateInstance(fullItemName);
            GameObject newItemIcon = AssembleGrid(item.spritePath, 0);
            newItemIcon.name = "ItemIcon";
            newItemIcon.tag = fullItemName;
            newItemIcon.transform.parent = slotList[i].transform;
            newItemIcon.transform.GetComponent<RectTransform>().anchoredPosition3D =new Vector3(0, 0, 0);
            i++;
        }
    }

    //if num == 0 means weaponItem/equipmentItem 
    private GameObject AssembleGrid(string spriteIconPath,int num)
    {
        GameObject newItemIcon = Instantiate(itemIcon);
        Sprite icon = Resources.Load<Sprite>(spriteIconPath);
        newItemIcon.GetComponent<Image>().overrideSprite = icon;
        if (num!=0)
        {
            newItemIcon.transform.GetChild(0).gameObject.GetComponent<Text>().text = num+"";
        }

        return newItemIcon;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        backpackMenu.SetActive(false);
        backpackDescriptionPanel.SetActive(false);
        target = null;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == "ItemIcon")
            {
                target = result.gameObject;
                targetPosition = new Vector3(eventData.position.x,eventData.position.y,0);
                backpackMenu.transform.position = new Vector3(eventData.position.x+65,eventData.position.y-65,0);
                backpackMenu.SetActive(true);
                break;
            }
        }
    }

    private void ClearView()
    {
        for (int i=0; i< slotList.Count;i++ )
        {
            if (slotList[i].transform.childCount>0)
            {
                Destroy(slotList[i].transform.GetChild(0).gameObject);
            }
            else
            {
                break;
            }

        }
    }
    public void UseOrEquip()
    {
        backpackMenu.SetActive(false);
        if (target!=null)
        {
            String fullItemName = target.tag;
            BackpackManager.Instance.UseOrEquip(fullItemName);
        }
    }
    
    

    public void ShowDescription()
    {
        backpackMenu.SetActive(false);
        if (target!=null)
        {
            String fullItemName = target.tag;
            BaseItem item = (BaseItem)GameManager.assembly.CreateInstance(fullItemName);
            backpackDescriptionPanel.transform.position = new Vector3(targetPosition.x+70, targetPosition.y-90, 0);
            (backpackDescriptionPanel.transform.GetChild(0).gameObject.GetComponent<Text>()).text = item.description;
            backpackDescriptionPanel.SetActive(true);
        }
    }

    public void DropItem()
    {
        backpackMenu.SetActive(false);
        if (target != null)
        {
            String fullItemName = target.tag;
            BackpackManager.Instance.DropItem(fullItemName);
        }
    }
}
