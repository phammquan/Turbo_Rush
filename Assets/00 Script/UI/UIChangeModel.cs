using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIChangeModel : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] Button _buttonBack;
    [SerializeField] Button _buttonNext;
    [SerializeField] Button _buttonPlay;
    [SerializeField] Button _buttonBuy;
    [SerializeField] Button _buttonsetting;
    [SerializeField] GameObject _panelSetting;
    public LeanTweenType EseType;



    
    [Space]
    [Header("Text")]
    [SerializeField] TextMeshProUGUI _textDiamond;
    private int _selectionIndex;
    [SerializeField] int _maxIndex;
    private bool _isSetting;

    void Awake()
    {
        Observer.AddListener("CheckUnlock", CheckUnlock);
        Observer.Notify("ChangeModel", _selectionIndex);
        _textDiamond.text = PlayerPrefs.GetInt("Diamond").ToString();
        _selectionIndex = 0;
        _buttonBack.onClick.AddListener(Back);
        _buttonNext.onClick.AddListener(Next);
        _buttonPlay.onClick.AddListener(() =>
        {
            SoundController.Instance.musicSource.Stop();
            SoundController.Instance.SFXPlay("Button");
            SceneManager.LoadScene("Game");
        });
        _buttonBuy.onClick.AddListener(Buy);
        _buttonsetting.onClick.AddListener(Setting);
    }
    void OnDestroy()
    {
        Observer.RemoveListener("CheckUnlock", CheckUnlock);
    }

    void Back()
    {
        SoundController.Instance.SFXPlay("Button");
        Debug.Log("Back");
        if (_selectionIndex == 0)
        {
            _selectionIndex = _maxIndex;
        }
        else
        {
            _selectionIndex--;
        }

        Observer.Notify("ChangeModel", _selectionIndex);
        PlayerPrefs.SetInt("Model",_selectionIndex);
        PlayerPrefs.Save();

    }

    void Next()
    {
        SoundController.Instance.SFXPlay("Button");
        Debug.Log("Next");
        if (_selectionIndex == _maxIndex)
        {
            _selectionIndex = 0;
        }
        else
        {
            _selectionIndex++;
        }

        Observer.Notify("ChangeModel", _selectionIndex);
        PlayerPrefs.SetInt("Model",_selectionIndex);
        PlayerPrefs.Save();

    }

    void CheckUnlock(object[] datas)
    {
        if (!(bool)datas[0])
        {
            _buttonPlay.interactable = false;
            _buttonBuy.interactable = true;
        }
        else
        {
            _buttonPlay.interactable = true;
            _buttonBuy.interactable = false;
        }
    }

    void Buy()
    {
        SoundController.Instance.SFXPlay("Button");
        Observer.Notify("Buy", _selectionIndex);
        _textDiamond.text = PlayerPrefs.GetInt("Diamond").ToString();
        Observer.Notify("ChangeModel", _selectionIndex);
    }
    public void Setting()
    {
        _isSetting = !_isSetting;
        if (_isSetting)
        {
            SoundController.Instance.SFXPlay("Popup Open");
            LeanTween.scale(_panelSetting, new Vector3(1.2f, 1.2f, 1.2f), 0.5f).setEase(EseType)
                .setIgnoreTimeScale(true).setOnComplete(() =>
                {
                    LeanTween.scale(_panelSetting, new Vector3(1f, 1f, 1f), 0.2f).setIgnoreTimeScale(true);
                });
        }

        else
        {
            SoundController.Instance.SFXPlay("Popup Close");
            LeanTween.scale(_panelSetting, new Vector3(0f, 0f, 0f), 0.5f).setEase(EseType).setIgnoreTimeScale(true);
        }
    }

}