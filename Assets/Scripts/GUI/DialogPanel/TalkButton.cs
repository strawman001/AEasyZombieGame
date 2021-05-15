using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkButton : MonoBehaviour
{
    private static TalkButton instance = null;
    private TalkButton(){}
    public static TalkButton Instance
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

    public void SetTalkButton(Action action)
    {
        GetComponent<Button>().onClick.AddListener(delegate
        {
            action();
            HideTalkButton();
        });
    }

    public void ShowTalkButton()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

    }

    public void HideTalkButton()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
