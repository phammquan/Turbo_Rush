using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeModel : MonoBehaviour
{
    [SerializeField] Button _buttonBack;
    [SerializeField] Button _buttonNext;
    [SerializeField] Button _buttonPlay;
    private int _selectionIndex;
    [SerializeField] int _maxIndex;

    void Start()
    {
        _selectionIndex = 0;
        _buttonBack.onClick.AddListener(Back);
        _buttonNext.onClick.AddListener(Next);
        _buttonPlay.onClick.AddListener(() => { SceneManager.LoadScene("Game"); });
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
        PlayerPrefs.SetInt("Model", _selectionIndex);
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
        PlayerPrefs.SetInt("Model", _selectionIndex);
        PlayerPrefs.Save();
    }
}