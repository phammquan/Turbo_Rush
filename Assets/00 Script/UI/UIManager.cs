using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Button InGame")]
    [SerializeField] Button _buttonPlayPause;
    [SerializeField] bool _isPause = false;
    [SerializeField] private List<Button> _listFnButton;
    [SerializeField] private LeanTweenType EseType;
    [SerializeField] GameObject _panelGameOver;
    [Space] [SerializeField] TextMeshProUGUI _diamondText;
    [SerializeField] TextMeshProUGUI _distanceText;
    [SerializeField] Slider _hp;
    private bool _maxhp = false;
    private float _distanceBtn;
    private float _timeBtn;
    public static UIManager Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Observer.AddListener("UpdateDiamondText", UpdateDiamondCount);
        Observer.AddListener("UpdateDistanceText", UpdateDistanceText);
        Observer.AddListener("UpdateHP", UpdateHP);
        Observer.AddListener("GameOver", UpdateGameOver);
    }

    private void OnDestroy()
    {
        Observer.RemoveListener("UpdateDiamondText", UpdateDiamondCount);
        Observer.RemoveListener("UpdateDistanceText", UpdateDistanceText);
        Observer.RemoveListener("UpdateHP", UpdateHP);
        Observer.RemoveListener("GameOver", UpdateGameOver);

    }

    private void UpdateGameOver(object[] obj)
    {
        _panelGameOver.SetActive(true);
        LeanTween.scale(_panelGameOver, new Vector3(1.2f, 1.2f, 1.2f), 0.5f).setEase(EseType).setOnComplete(() =>
        {
            LeanTween.scale(_panelGameOver, new Vector3(1f, 1f, 1f), 0.2f);
        });
    }

    private void Start()
    {
        _buttonPlayPause.onClick.AddListener(Pause);
        _listFnButton[2].onClick.AddListener(RePlay);
        _listFnButton[1].onClick.AddListener(Home);

    }

    private void UpdateHP(object[] obj)
    {
        if (_hp == null)
        {
            Debug.LogError("Slider _hp đã bị hủy.");
            return;
        }
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

    void Pause()
    {
        _isPause = !_isPause;
        Time.timeScale = _isPause ? 0f : 1f;
        _buttonPlayPause.interactable = false;
        _distanceBtn = 240 * 3;
        _timeBtn = .5f;

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
                LeanTween.moveLocalY(_btn.gameObject, _btn.transform.localPosition.y - _distanceBtn, _timeBtn)
                    .setEase(EseType)
                    .setIgnoreTimeScale(true);
                _distanceBtn -= 240;
                _timeBtn += .1f;
            }
            else
            {
                _btn.interactable = false;
                LeanTween.moveLocalY(_btn.gameObject, _btn.transform.localPosition.y + _distanceBtn, _timeBtn)
                    .setEase(EseType)
                    .setIgnoreTimeScale(true)
                    .setOnComplete(() => { _btn.gameObject.SetActive(false); });
                _distanceBtn -= 240;
                _timeBtn += .1f;
            }
        }

        StartCoroutine(DelayPause());
    }

    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator DelayPause()
    {
        yield return new WaitForSecondsRealtime(1f);
        _buttonPlayPause.interactable = true;
    }
}