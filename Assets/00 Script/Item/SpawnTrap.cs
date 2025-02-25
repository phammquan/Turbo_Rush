using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTrap : MonoBehaviour
{
    [SerializeField] GameObject _trap;
    void Start()
    {
        Observer.AddListener("SpawnTrap", spawnTrap);
    }
    void OnDestroy()
    {
        Observer.RemoveListener("SpawnTrap", spawnTrap);
    }

    void spawnTrap(object[] datas)
    {
        GameObject objTrap = Object_Pooling.Instance.GetPrefabs(_trap);
        objTrap.transform.position = (Vector3)datas[0];
        objTrap.transform.position += new Vector3(0, 0.6f, 0);
        objTrap.SetActive(true);
    }
}
