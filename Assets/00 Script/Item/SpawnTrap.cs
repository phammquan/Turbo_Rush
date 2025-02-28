using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTrap : MonoBehaviour
{
    [SerializeField] GameObject _trap;
    [SerializeField] GameObject _boom;

    void Start()
    {
        Observer.AddListener("SpawnTrap", SpawnBoom);
    }
    void OnDestroy()
    {
        Observer.RemoveListener("SpawnTrap", SpawnBoom);
    }

    void spawnTrap(object[] datas)
    {
        GameObject objTrap = Object_Pooling.Instance.GetPrefabs(_trap);
        objTrap.transform.position = (Vector3)datas[0];
        objTrap.transform.position += new Vector3(0, 0.6f, 0);
        objTrap.SetActive(true);
    }

    void SpawnBoom(object[] datas)
    {
        GameObject objTrap = Object_Pooling.Instance.GetPrefabs(_boom);
        objTrap.transform.position = (Vector3)datas[0];
        objTrap.transform.position += new Vector3(Random.Range(-1,1), 0.9f, Random.Range(-1,1));
        objTrap.SetActive(true);
    }
}
