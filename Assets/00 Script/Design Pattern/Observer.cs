using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Observer : Singleton<Observer>
{
    static Dictionary<string, List<Action<object[]>>> _listAction = new Dictionary<string, List<Action<object[]>>>();

    public static void AddListener(string eventName, Action<object[]> callback)
    {
        if(!_listAction.ContainsKey(eventName))
            _listAction.Add(eventName, new List<Action<object[]>>());
        _listAction[eventName].Add(callback);
    }
    public static void RemoveListener(string eventName, Action<object[]> callback)
    {
        if (!_listAction.ContainsKey(eventName))
            return;
        _listAction[eventName].Remove(callback);
    }

    public static void Notify(string eventName, params object[] datas)
    {
        if (!_listAction.ContainsKey(eventName))
            return;
        foreach (var item in _listAction[eventName])
        {
            try
            {
                item?.Invoke(datas);
            }catch(Exception e)
            {
                Debug.LogError(e);
            }          
        }
    }
}
