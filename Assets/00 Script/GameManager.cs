using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool _gameOver;
    public bool _GameOver => _gameOver;
    private int _diamondCount = 0;
    private int _diamondData = 0;
    private float _distance = 0;
    private float _time = 0;
    
    
    void Start()
    {
        _gameOver = false;
        Time.timeScale = 0f;
        Observer.AddListener("ContinueGame", ContinueGame);
        Observer.AddListener("DiamondCount", DiamondCount);
        Observer.AddListener("GameOver", GameOver);
        Observer.AddListener("PauseGame", PauseGame);
    }

    private void OnDestroy()
    {
        Observer.RemoveListener("ContinueGame", ContinueGame);
        Observer.RemoveListener("DiamondCount", DiamondCount);
        Observer.RemoveListener("GameOver", GameOver);
        Observer.RemoveListener("PauseGame", PauseGame);
    }

    private void Update()
    {
        CalcuDistance(null);
    }

    void ContinueGame(object[] datas)
    {
        Time.timeScale = 1f;
    }
    void PauseGame(object[] datas)
    {
        Time.timeScale = 0f;
    }
    void DiamondCount(object[] datas)
    {
        _diamondCount++;
        PlayerPrefs.SetInt("DiamondCount", _diamondCount);
        Observer.Notify("UpdateDiamondText", _diamondCount);
    }
    void CalcuDistance(object[] datas)
    {
        if(_gameOver) return;
        _distance = 3 * (_time += Time.deltaTime);
        Observer.Notify("UpdateDistanceText", _distance);
    }
    void GameOver(object[] datas)
    {
        _gameOver = (bool)datas[0];
        _diamondData = PlayerPrefs.GetInt("Diamond");
        _diamondData += PlayerPrefs.GetInt("DiamondCount");
        PlayerPrefs.SetInt("Diamond", _diamondData);
        PlayerPrefs.Save();
        Observer.Notify("UpdateResult", _distance, (float)_diamondCount);
    }
    public void CheckSingleTon()
    {
        Debug.Log("CheckSingleTon");
    }
}
