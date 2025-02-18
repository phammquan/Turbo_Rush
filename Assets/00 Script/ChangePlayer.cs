using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    [SerializeField] List<GameObject> _modelList;
    private int _selectionIndex;
    void Start()
    {
        _selectionIndex = PlayerPrefs.GetInt("Model");
        _modelList = new List<GameObject>();
        foreach (Transform model in transform)
        {
            _modelList.Add(model.gameObject);
            model.gameObject.SetActive(false);
        }
        _modelList[_selectionIndex].SetActive(true);
    }

}
