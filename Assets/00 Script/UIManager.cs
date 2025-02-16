using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _diamondText;
    void Start()
    {
        Observer.AddListener("UpdateDiamondText", UpdateDiamondCount);
    }

    void UpdateDiamondCount(object[] datas)
    {
        _diamondText.text = datas[0].ToString();
    }
}
