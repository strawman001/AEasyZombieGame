using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMessageManager : MonoBehaviour
{
    private static UserMessageManager instance = null;
    private UserMessageManager(){}
    public static UserMessageManager Instance
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
    
    private static List<string> userMessageList = new List<string>();

    public void AddUserMessage(String message)
    {
        userMessageList.Add(message);
        UserMessageUI.Instance.AddNewShowMessage(message);
    }
    
    
}
