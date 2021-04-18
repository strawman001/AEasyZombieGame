using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeUI : MonoBehaviour
{
    private static AttributeUI instance = null;
    private AttributeUI(){}
    public static AttributeUI Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    
    private Dictionary<string,GameObject> textPropertyDic = new Dictionary<string, GameObject>();
    private Dictionary<string,GameObject> buttonRedDic = new Dictionary<string, GameObject>();
    public List<GameObject> textPropertyList;
    public List<GameObject> buttonAddList;
    public List<GameObject> buttonRedList;
    public GameObject confirmButton;
    
    private void Start()
    {
        foreach (GameObject text in textPropertyList)
        {
            textPropertyDic.Add(text.name,text);
        }
        foreach (GameObject button in buttonRedList)
        {
            buttonRedDic.Add(button.name,button);
        }
    }


    public void OnClickAddButton(string attrName)
    {
        PlayerPropertyManager.Instance.AddInnerAttribute(attrName);
    }

    public void OnClickReduceButton(string attrName)
    {
        PlayerPropertyManager.Instance.ReduceInnerAttribute(attrName);
    }
    
    public void ShowProperty()
    {
        foreach (KeyValuePair<string,string> pair in PlayerPropertyManager.Instance.GetProperty())
        {
            
            textPropertyDic[pair.Key].GetComponent<Text>().text = pair.Value;
        }
        
        UpdateButtonStatus();
    } 
    
    public void UpdatePanelStatus()
    {
        Dictionary<string, string> newPropertyDic = PlayerPropertyManager.Instance.GetUpdatedProperty();
        foreach (KeyValuePair<string,string> pair in PlayerPropertyManager.Instance.GetProperty())
        {
            if (newPropertyDic[pair.Key]==pair.Value)
            {
                textPropertyDic[pair.Key].GetComponent<Text>().text = pair.Value;
            }
            else
            {
                textPropertyDic[pair.Key].GetComponent<Text>().text = pair.Value + "->" + newPropertyDic[pair.Key];
            }
        }
        
        UpdateButtonStatus();
    }

    private void UpdateButtonStatus()
    {

        confirmButton.GetComponent<Button>().interactable = PlayerPropertyManager.Instance.isConfirmable();
        
        if (PlayerPropertyManager.Instance.isAvailable())
        {
            foreach (GameObject button in buttonAddList)
            {
                button.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            foreach (GameObject button in buttonAddList)
            {
                button.GetComponent<Button>().interactable = false;
            }
        }

        foreach (KeyValuePair<string,bool> pair in PlayerPropertyManager.Instance.GetIsChangedProperty())
        {
            buttonRedDic[pair.Key].GetComponent<Button>().interactable = pair.Value;
        }
        
    }

    public void OnClickConfirm()
    {
        PlayerPropertyManager.Instance.ConfirmChange();
    }
}
