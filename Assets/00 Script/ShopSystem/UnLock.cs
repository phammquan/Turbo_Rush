using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnLock : MonoBehaviour
{
    public SOPlayerData playerData;
    public bool unLock;
    public int price;
    private void Start()
    {
        price = playerData.price;
        Observer.AddListener("BuyComplete", UpdateUnlock);
    }

    private void UpdateUnlock(object[] obj)
    {
        unLock = true;
    }
}
