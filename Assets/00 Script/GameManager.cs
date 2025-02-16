using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _diamondCount = 0;
    
    void Start()
    {
        Time.timeScale = 0f;
        Observer.AddListener("ContinueGame", ContinueGame);
        Observer.AddListener("DiamondCount", DiamondCount);
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
}
