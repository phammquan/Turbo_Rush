using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarData : MonoBehaviour
{
    [SerializeField] List<SOPlayerData> _listCarData;
    private int _selectionIndex;

    private void Start()
    {
        _selectionIndex = PlayerPrefs.GetInt("Model");
        Debug.Log(_selectionIndex);
        Observer.Notify("GetData", _listCarData[_selectionIndex]);
    }
    
}
