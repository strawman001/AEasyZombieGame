using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserMessageUI : MonoBehaviour
{
    private static UserMessageUI instance = null;
    private UserMessageUI(){}
    public static UserMessageUI Instance
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

    private int size = 0;
    private bool isShowing = false;
    private bool isMoving = false;
    private Queue messageList = new Queue();

    private RectTransform rectTransform;

    public Text userMessageLabel;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        
    }

    private void Update()
    {
        if (size!=0&&!isShowing&&!isMoving)
        {
            ShowNewMessage();
        }
    }

    public void AddNewShowMessage(string message)
    {
        messageList.Enqueue(message);
        size++;
    }

    public void ShowNewMessage()
    {
        size--;
        isShowing = true;
        string newMessage = (string)messageList.Dequeue();
        userMessageLabel.text = newMessage;
        StartCoroutine(CloseTimerByWaiting());
        ShowUserMessagePanel();
    }

    IEnumerator CloseTimerByWaiting()
    {
        yield return new WaitForSeconds(3);
        HideUserMessagePanel();
        isShowing = false;
        
    }

    public void CloseTimerByButton()
    {
        HideUserMessagePanel();
        isShowing = false;
        StopCoroutine(CloseTimerByWaiting());
    }

    public void ShowUserMessagePanel()
    {
        isMoving = true;
        StartCoroutine(MovePanel(new Vector3(0, -200, 0) * 0.5f,20));
    }

    public void HideUserMessagePanel()
    {
        isMoving = true;
        StartCoroutine(MovePanel(new Vector3(0, 200, 0) * 0.5f,20));
    }

    IEnumerator MovePanel(Vector3 speed, int times)
    {
        for (int i = 0; i < times; i++)
        {
            rectTransform.Translate(speed);
            yield return null;
        }

        isMoving = false;
    }
    
}
