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
    RectTransform _rectTransform;
    

    void Start()
    {
        Vector3 _posPlay = _buttonPlay.transform.localPosition;
        _openShop = false;
        _btnShop.onClick.AddListener(() =>
        {
            _cameraZ = _openShop ? -10 : -7;
            LeanTween.moveLocalZ(Camera.main.gameObject, _cameraZ, 1f).setEase(EaseType);
            LeanTween.moveLocalY(_buttonPlay.gameObject, _openShop ? _posPlay.y : _posPlay.y - 210, 0.5f).setEase(EaseType);
            _openShop = !_openShop;

        });
        
    }
    
}
