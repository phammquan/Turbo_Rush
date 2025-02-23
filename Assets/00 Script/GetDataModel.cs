using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GetDataModel : MonoBehaviour
{
    [SerializeField] List<SOPlayerData> _dataModelList;
    [SerializeField] private Slider _hp;
    [SerializeField] private Slider _speed;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _name;

    private int _selectionIndex;

    private void Start()
    {
        _selectionIndex = PlayerPrefs.GetInt("Model");
        Debug.Log(_selectionIndex);
        UpdateDataModel(new object[] { _selectionIndex });
        Observer.AddListener("ChangeModel", UpdateDataModel);
    }
    
    private void UpdateDataModel(object[] obj)
    {
        _selectionIndex = (int)obj[0];
        _name.text = _dataModelList[_selectionIndex].name;
        _hp.value = _dataModelList[_selectionIndex].Hp;
        _speed.value = _dataModelList[_selectionIndex].Speed;
        _price.text = _dataModelList[_selectionIndex].price.ToString();
    }
}
