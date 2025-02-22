using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITween : MonoBehaviour
{
    [SerializeField] GameObject _UIShop;
    [SerializeField]  GameObject _NameInGame;
    [SerializeField] GameObject _inforShop;
    [SerializeField] Button _btnShop, _buttonPlay, _buttonBuy, _buttonBack, _buttonNext;
    [SerializeField] bool _openShop;
    [SerializeField] float _cameraZ;
    [SerializeField] LeanTweenType EaseType;
    RectTransform _rectTransform;



    void Start()
    {
        Vector3 posPlay = _buttonPlay.transform.localPosition;
        Vector3 posBuy = _buttonBuy.transform.localPosition;
        Vector3 posBack = _buttonBack.transform.localPosition;
        Vector3 posNext = _buttonNext.transform.localPosition;
        Vector3 posName = _NameInGame.transform.localPosition;

        
        _openShop = false;
        _btnShop.onClick.AddListener(() =>
        {
            Debug.Log("Shop");
            if (LeanTween.isTweening())
                return;
            if(!_openShop) 
                _UIShop.gameObject.SetActive(true);
            else
                _UIShop.gameObject.SetActive(false);
            // if(!_openShop)   
            //     _buttonBuy.gameObject.SetActive(true);
            // else
            //     _buttonBuy.gameObject.SetActive(false);
            LeanTween.moveLocalY(_NameInGame.gameObject, _openShop ? posName.y : posName.y + 190, 0.5f).setEase(EaseType);
            LeanTween.scale(_inforShop, _openShop ? new Vector3(0, 0, 0) : new Vector3(1, 1, 1), 1f).setEase(EaseType);

            _cameraZ = _openShop ? -10 : -7;
            LeanTween.moveLocalZ(Camera.main.gameObject, _cameraZ, 0.5f).setEase(EaseType);
            LeanTween.moveLocalY(_buttonPlay.gameObject, _openShop ? posPlay.y : posPlay.y - 450, 0.5f).setEase(EaseType);
            LeanTween.moveLocalY(_buttonBuy.gameObject, _openShop ? posBuy.y : posBuy.y - 450, 0.6f).setEase(EaseType);
            LeanTween.moveLocalX(_buttonBack.gameObject, _openShop ? posBack.x : posBack.x + 500, 0.5f).setEase(EaseType);
            LeanTween.moveLocalX(_buttonNext.gameObject, _openShop ? posNext.x : posNext.x - 500, 0.5f).setEase(EaseType);
            _openShop = !_openShop;
        });
    }
    
    
    
}
