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
    
    [Space]
    [Header("Text")]
    [SerializeField] TextMeshProUGUI _textDiamond;
    private int _selectionIndex;
    [SerializeField] int _maxIndex;

    void Awake()
    {
        Observer.Notify("ChangeModel", _selectionIndex);
        Observer.AddListener("CheckUnlock", CheckUnlock);
        _textDiamond.text = PlayerPrefs.GetInt("Diamond").ToString();
        _selectionIndex = 0;
        _buttonBack.onClick.AddListener(Back);
        _buttonNext.onClick.AddListener(Next);
        _buttonPlay.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game");
        });
        _buttonBuy.onClick.AddListener(Buy);
    }

    void Back()
    {
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
        Observer.Notify("Buy", _selectionIndex);
        _textDiamond.text = PlayerPrefs.GetInt("Diamond").ToString();
        Observer.Notify("ChangeModel", _selectionIndex);
    }
    
}