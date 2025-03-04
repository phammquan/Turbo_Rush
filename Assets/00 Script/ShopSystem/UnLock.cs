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
    
    private void Awake()
    {
        unLock = playerData.unLock;
        price = playerData.price;
        Observer.AddListener("BuyComplete", UpdateUnlock);
    }

    private void OnDestroy()
    {
        Observer.RemoveListener("BuyComplete", UpdateUnlock);
    }

    private void UpdateUnlock(object[] obj)
    {
        int purchasedIndex = (int)obj[0];
        if (this.gameObject == ShopSystem.Instance.GetCarByIndex(purchasedIndex))
        {
            unLock = true;
            playerData.unLock = true;
        }
    }
}