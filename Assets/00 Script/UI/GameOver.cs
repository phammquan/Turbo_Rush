using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _panel;

    [SerializeField] private Button _rePlay;
    [SerializeField] private Button _home;
    [SerializeField] private Button _setting;
    [Header("Button")]
    [SerializeField] private TextMeshProUGUI _DistanceTotal;
    [SerializeField] private TextMeshProUGUI _DiamondTotal;
    [SerializeField] LeanTweenType EaseType;

    private void Awake()
    {
        Observer.AddListener("UpdateResult", ResultTotal);

    }
    
    void Start()
    {
        _rePlay.onClick.AddListener(() =>
        {
           UIManager.Instance.RePlay();
        });
        _home.onClick.AddListener(() =>
        {
            UIManager.Instance.Home();
        });
        _panel.SetActive(true);
        LeanTween.scale(_panel.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.75f).setEase(EaseType).setOnComplete(() =>
        {
            LeanTween.scale(_panel.gameObject, new Vector3(1f, 1f, 1f), 0.2f);
            _DiamondTotal.gameObject.SetActive(true);
        });
        
    }
    void OnDestroy()
    {
        Observer.RemoveListener("UpdateResult", ResultTotal);
    }
    
    void ButtonCtrl()
    {
        LeanTween.scale(_home.gameObject, new Vector3(1f,1f,1f), .5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(_rePlay.gameObject, new Vector3(1f,1f,1f), .5f).setDelay(.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(_setting.gameObject, new Vector3(1f,1f,1f), .5f).setDelay(.2f).setEase(LeanTweenType.easeOutElastic);
        
    }
    // void ResultTotal(object[] datas)
    // {
    //     LeanTween.value(0,(float)datas[0],1).setOnUpdate((float val) =>
    //     {
    //         Debug.Log(val);
    //         _DistanceTotal.text = Math.Round(val) + "m";
    //         LeanTween.scale(_DistanceTotal.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 1f).setEase(EaseType).setOnComplete(() =>
    //         {
    //             LeanTween.scale(_DistanceTotal.gameObject, new Vector3(1f, 1f, 1f), 1f).setEase(EaseType);
    //         });
    //     }).setOnComplete(() =>
    //     {
    //         LeanTween.value(0, (float)datas[1], 1).setOnUpdate((float val) =>
    //         {
    //             _DiamondTotal.text = Math.Round(val).ToString();
    //         });
    //     });
    // }
    void ResultTotal(object[] datas)
    {
        if (datas == null || datas.Length < 2)
        {
            Debug.LogError("ResultTotal: Không đủ tham số.");
            return;
        }

        if (!(datas[0] is float distance)) distance = Convert.ToSingle(datas[0]);
        if (!(datas[1] is float diamonds)) diamonds = Convert.ToSingle(datas[1]);

        // Hiển thị khoảng cách với hiệu ứng scale
        LeanTween.value(0, distance, 0.5f).setOnUpdate((float val) =>
        {
            _DistanceTotal.text = Math.Round(val) + "m";
        }).setEase(EaseType).setOnComplete(() =>
        {
            ButtonCtrl();
            ScaleEffect(_DistanceTotal.gameObject, () =>
            {
                LeanTween.value(0, diamonds, 0.5f).setOnUpdate((float val) =>
                {
                    _DiamondTotal.text = Math.Round(val).ToString();
                }).setEase(EaseType).setOnComplete(() =>
                {
                    ScaleEffect(_DiamondTotal.gameObject, null);
                });
            });
        });
    }

    void ScaleEffect(GameObject obj, Action onComplete)
    {
        LeanTween.scale(obj, new Vector3(1.5f, 1.5f, 1.5f), 0.5f).setEase(EaseType).setOnComplete(() =>
        {
            LeanTween.scale(obj, Vector3.one, 0.5f).setEase(EaseType).setOnComplete(onComplete);
        });
    }

}
