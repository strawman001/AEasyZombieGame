using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    private static DialogUI instance = null;
    private DialogUI(){}
    public static DialogUI Instance
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
    
    public GameObject dialogTextObject;
    public GameObject dialogOptionList;
    public GameObject nextButton;

    private GameObject dialogSelectItem;
    private DialogTree dialogTree;
    private Text dialogText;
    private Button nextButtonComponent;
    private CanvasGroup canvasGroup;
    private void Start()
    {
        dialogSelectItem = Resources.Load("Prefab/UI/DialogSelectItem") as GameObject;
        dialogText = dialogTextObject.GetComponent<Text>();
        nextButtonComponent = nextButton.GetComponent<Button>();
        canvasGroup = GetComponent<CanvasGroup>();
        nextButtonComponent.onClick.AddListener(delegate
        {
            GoNextDialogNode();
            ShowDialogNodeContent();
        });
    }

    public void SetDialogTree(DialogTree dialogTree)
    {
        this.dialogTree = dialogTree;
    }

    public void BeginDialog(DialogTree dialogTree)
    {
        this.dialogTree = dialogTree;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
        ShowDialogNodeContent();
    }

    public void StopDialog()
    {
        this.dialogTree = null;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
        ClearOptionListView();
    }

    public void GoNextDialogNode()
    {
        dialogTree.GoNextDialogNode();
    }
    
    public void GoNextDialogNode(int position)
    {
        dialogTree.GoNextDialogNode(position);
    }

    public void ShowDialogNodeContent()
    {
        Dictionary<string,object> info = dialogTree.GetCurrentDialogNodeInfo();
        switch (info["Type"])
        {
            case DialogNode.DIALOG_GENERAL_NODE:
                dialogText.text = (string) info["Data"];
                nextButtonComponent.interactable = true;
                break;
            case DialogNode.DIALOG_SELECT_NODE:
                ShowOptionList((List<string>)info["Data"]);
                nextButtonComponent.interactable = false;
                break;
            case DialogNode.DIALOG_END_NODE:
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0;
                ClearOptionListView();
                break;

        }
    }

    private void ShowOptionList(List<string> options)
    {
        for (int i = 0; i < options.Count; i++)
        {
            GameObject optionItem = Instantiate(dialogSelectItem, dialogOptionList.transform, true);
            optionItem.transform.GetChild(0).GetComponent<Text>().text = options[i];
            int position = i;
            optionItem.GetComponent<Button>().onClick.AddListener(delegate
            {
                GoNextDialogNode(position);
                ShowDialogNodeContent();
                ClearOptionListView();
            });
        }
        
    }

    private void ClearOptionListView()
    {
        for (int i = 0; i < dialogOptionList.transform.childCount; i++)
        {
            Destroy(dialogOptionList.transform.GetChild(i).gameObject);
        }
    }
}
