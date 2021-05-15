using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObserver
{
   private Dictionary<string, List<TaskListener>> taskListenerDictionary = new Dictionary<string, List<TaskListener>>();

   public void AddListener(String eventName, TaskListener taskListener)
   {
      if (!taskListenerDictionary.ContainsKey(eventName))
      {
         taskListenerDictionary.Add(eventName, new List<TaskListener>() {taskListener});
      }
      else
      {
         List<TaskListener> taskListenerList = taskListenerDictionary[eventName];
         taskListenerList.Add(taskListener);
      }
   }

   public void NotifyAllListener(String eventName)
   {
      if (taskListenerDictionary.ContainsKey(eventName))
      {
         List<TaskListener> taskListenerList = taskListenerDictionary[eventName];
         if (taskListenerList==null)
         {
            return;
         }
         foreach (TaskListener taskListener in taskListenerList)
         {
            taskListener.SendMessage();
         }
      }
   }
   
   
}
