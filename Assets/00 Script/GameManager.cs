using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        Time.timeScale = 0f;
        Observer.AddListener("ContinueGame", ContinueGame);
    }

    void ContinueGame(object[] datas)
    {
        Time.timeScale = 1f;
    }
}
