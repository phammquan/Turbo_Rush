using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : Singleton<ShopSystem>
{
    [SerializeField] private List<GameObject> _listPrice = new List<GameObject>();
    [SerializeField] private Dictionary<int, GameObject> _carDictionary = new Dictionary<int, GameObject>();

    private int _currentDiamond;
    void Start()
    {
        Observer.AddListener("Buy", Buy);
        _currentDiamond = PlayerPrefs.GetInt("Diamond");
        for (int i = 0; i < _listPrice.Count; i++)
        {
            _carDictionary[i] = _listPrice[i];
        }
    }

    private void Buy(object[] datas)
    {
        int price = _listPrice[(int)datas[0]].GetComponent<UnLock>().price;
        if (_currentDiamond >= price)
        {
            _currentDiamond -= price;
            PlayerPrefs.SetInt("Diamond", _currentDiamond);
            PlayerPrefs.Save();
            Observer.Notify("BuyComplete", (int)datas[0]);
        }
        else
        {
            Debug.Log("Not enough diamond");
        }
    }
    public GameObject GetCarByIndex(int index)
    {
        return _carDictionary.ContainsKey(index) ? _carDictionary[index] : null;
    }
}
