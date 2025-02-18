using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelect : MonoBehaviour
{
    [SerializeField] List<GameObject> _modelList;
    private int _selectionIndex;
    void Start()
    {
        Observer.AddListener("ChangeModel", Select);
        _selectionIndex = PlayerPrefs.GetInt("Model");
        _modelList = new List<GameObject>();
        foreach (Transform model in transform)
        {
            _modelList.Add(model.gameObject);
            model.gameObject.SetActive(false);
        }
        _modelList[_selectionIndex].SetActive(true);
    }
    
    public void Select(object[] datas)
    {
        // if((int)datas[0] == _selectionIndex) return;
        // if((int)datas[0] < 0 || (int)datas[0] >= _modelList.Count) return;
        // _modelList[_selectionIndex].SetActive(false);
        // _selectionIndex = (int)datas[0];
        // _modelList[_selectionIndex].SetActive(true);
        _modelList[_selectionIndex].SetActive(false);
        _modelList[(int)datas[0]].SetActive(true);
        _selectionIndex = (int)datas[0];
    }
}
