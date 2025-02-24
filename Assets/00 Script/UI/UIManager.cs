using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button _buttonPlayPause;
    [SerializeField] bool _isPause = false;
    [SerializeField] private List<Button> _listFnButton;
    [SerializeField] private LeanTweenType EseType;
    [Space]
    [SerializeField] TextMeshProUGUI _diamondText;
    [SerializeField] TextMeshProUGUI _distanceText;
    [SerializeField] Slider _hp;
    private bool _maxhp = false;
    private float _distanceBtn;
    private float _timeBtn;

    void Awake()
    {
        Observer.AddListener("UpdateDiamondText", UpdateDiamondCount);
        Observer.AddListener("UpdateDistanceText", UpdateDistanceText);
        Observer.AddListener("UpdateHP", UpdateHP);
    }

    private void Start()
    {
        _buttonPlayPause.onClick.AddListener(() =>
        {
            _buttonPlayPause.interactable = false;
            _distanceBtn = 240*3; 
            _timeBtn = .5f;
            _isPause = !_isPause;
            if (_isPause)
            {    
                _buttonPlayPause.transform.GetChild(1).gameObject.SetActive(true);
                _buttonPlayPause.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                _buttonPlayPause.transform.GetChild(1).gameObject.SetActive(false);
                _buttonPlayPause.transform.GetChild(0).gameObject.SetActive(true);
            }

            foreach (Button _btn in _listFnButton)
            {
                if (_isPause)
                {
                    _btn.gameObject.SetActive(true);
                    _btn.interactable = true;
                    LeanTween.moveLocalY(_btn.gameObject, _btn.transform.localPosition.y - _distanceBtn, _timeBtn).setEase(EseType);
                    _distanceBtn -= 240;
                    _timeBtn += .1f;
                }
                else
                {
                    _btn.interactable = false;
                    LeanTween.moveLocalY(_btn.gameObject, _btn.transform.localPosition.y + _distanceBtn, _timeBtn).setEase(EseType)
                        .setOnComplete(() =>
                        {
                            _btn.gameObject.SetActive(false);
                            
                        });
                    _distanceBtn -= 240;
                    _timeBtn += .1f;
                }
            }
            StartCoroutine(DelayPause());
        });
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
    IEnumerator DelayPause()
    {
        yield return new WaitForSeconds(1f);
        _buttonPlayPause.interactable = true;
    }
}
