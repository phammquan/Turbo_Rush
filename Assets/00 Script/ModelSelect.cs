using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelect : MonoBehaviour
{
    [SerializeField] List<GameObject> _modelList;
    private int _selectionIndex;
    private bool _unLock;

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
        if (_modelList[_selectionIndex] != null)
        {
            _unLock = _modelList[_selectionIndex].GetComponent<UnLock>().unLock;
            Observer.Notify("CheckUnlock", _unLock);

        }
    }

    private void OnDestroy()
    {
        Observer.RemoveListener("ChangeModel", Select);
    }

    public void Select(object[] datas)
    {
        _modelList[_selectionIndex].SetActive(false);
        _modelList[(int)datas[0]].SetActive(true);
        _selectionIndex = (int)datas[0];
        if (!_modelList[_selectionIndex].gameObject.GetComponent<UnLock>().unLock)
        {
            _unLock = false;
            Observer.Notify("CheckUnlock", _unLock);
        }
        else
        {
            _unLock = true;
            Observer.Notify("CheckUnlock", _unLock);
        }
    }
}