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
    private bool _maxhp = false;
    void Awake()
    {
        Observer.AddListener("UpdateDiamondText", UpdateDiamondCount);
        Observer.AddListener("UpdateDistanceText", UpdateDistanceText);
        Observer.AddListener("UpdateHP", UpdateHP);
    }

    private void UpdateHP(object[] obj)
    {
        if (!_maxhp)
        {
            _hp.maxValue = (int)obj[0];
            _maxhp = true;            
        }
        _hp.value = (int)obj[0];
        LeanTween.scale(_hp.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.2f).setOnComplete(() =>
        {
            LeanTween.scale(_hp.gameObject, new Vector3(2f, 2f, 2f), 0.2f);
        });
    }

    void UpdateDiamondCount(object[] datas)
    {
        _diamondText.text = datas[0].ToString();
        LeanTween.scale(_diamondText.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.2f).setOnComplete(() =>
        {
            LeanTween.scale(_diamondText.gameObject, new Vector3(1f, 1f, 1f), 0.2f);
        });
    }
    void UpdateDistanceText(object[] datas)
    {
        float _distance = (float)Math.Round((float)datas[0]);
        _distanceText.text = _distance + "m";
    }
}
