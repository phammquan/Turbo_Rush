using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : Singleton<ShopSystem>
{
    [SerializeField] private List<GameObject> _listPrice = new List<GameObject>();
    private int _currentDiamond;
    void Start()
    {
        Observer.AddListener("Buy", Buy);
        _currentDiamond = PlayerPrefs.GetInt("Diamond");
    }

    private void Buy(object[] datas)
    {
        int price = _listPrice[(int)datas[0]].GetComponent<UnLock>().price;
        if (_currentDiamond >= price)
        {
            _currentDiamond -= price;
            PlayerPrefs.SetInt("Diamond", _currentDiamond);
            Observer.Notify("BuyComplete", (int)datas[0]);
        }
        else
        {
            Debug.Log("Not enough diamond");
        }
    }
    public GameObject GetCarByIndex(int index)
    {
        if (index >= 0 && index < _listPrice.Count)
        {
            return _listPrice[index];
        }
        return null;
    }
}
