using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _diamondText;
    [SerializeField]  TextMeshProUGUI _distanceText;
    void Start()
    {
        Observer.AddListener("UpdateDiamondText", UpdateDiamondCount);
        Observer.AddListener("UpdateDistanceText", UpdateDistanceText);
    }

    void UpdateDiamondCount(object[] datas)
    {
        _diamondText.text = datas[0].ToString();
    }
    void UpdateDistanceText(object[] datas)
    {
        float _distance = (float)Math.Round((float)datas[0]);
        _distanceText.text = _distance + "m";
    }
}
