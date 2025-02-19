using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool _gameOver;
    public bool _GameOver => _gameOver;
    private int _diamondCount = 0;
    private float _distance = 0;
    
    void Start()
    {
        _gameOver = false;
        Time.timeScale = 0f;
        Observer.AddListener("ContinueGame", ContinueGame);
        Observer.AddListener("DiamondCount", DiamondCount);
        Observer.AddListener("GameOver", GameOver);
    }

    private void Update()
    {
        CalcuDistance(null);
    }

    void ContinueGame(object[] datas)
    {
        Time.timeScale = 1f;
    }
    void DiamondCount(object[] datas)
    {
        _diamondCount++;
        PlayerPrefs.SetInt("Diamond", _diamondCount);
        Observer.Notify("UpdateDiamondText", _diamondCount);
    }
    void CalcuDistance(object[] datas)
    {
        if(_gameOver) return;
        _distance = 3 * Time.time;
        Observer.Notify("UpdateDistanceText", _distance);
    }
    void GameOver(object[] datas)
    {
        _gameOver = (bool)datas[0];
    }
}
