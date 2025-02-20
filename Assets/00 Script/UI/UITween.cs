using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITween : MonoBehaviour
{
    [SerializeField] Button _btnShop, _buttonPlay;
    private bool _openShop;
    [SerializeField] float _cameraZ;
    [SerializeField] LeanTweenType EaseType;
    

    void Start()
    {
        _openShop = false;
        _btnShop.onClick.AddListener(() =>
        {
            _cameraZ = _openShop ? -10 : -7;
            LeanTween.moveZ(Camera.main.gameObject, _cameraZ, 1f).setEase(EaseType);
            _openShop = !_openShop;
            
        });
        
    }
    
}
