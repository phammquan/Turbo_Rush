using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _diamondCount = 0;
    
    private float _distance = 0;
    
    void Start()
    {
        Time.timeScale = 0f;
        Observer.AddListener("ContinueGame", ContinueGame);
        Observer.AddListener("DiamondCount", DiamondCount);
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
        Observer.Notify("UpdateDiamondText", _diamondCount);
    }
    void CalcuDistance(object[] datas)
    {
        _distance = 3 * Time.time;
        Observer.Notify("UpdateDistanceText", _distance);
    }
}
