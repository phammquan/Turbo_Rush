using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _diamondText;
    [SerializeField]  TextMeshProUGUI _distanceText;
    [SerializeField] Slider _hp;
    void Awake()
    {
        Observer.AddListener("UpdateDiamondText", UpdateDiamondCount);
        Observer.AddListener("UpdateDistanceText", UpdateDistanceText);
        Observer.AddListener("UpdateHP", UpdateHP);
    }

    private void UpdateHP(object[] obj)
    {
        _hp.maxValue = (int)obj[0];
        Debug.Log(obj[0]);
        _hp.value = (int)obj[0];
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
