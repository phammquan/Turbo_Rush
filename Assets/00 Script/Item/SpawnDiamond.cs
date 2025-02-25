using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDiamond : MonoBehaviour
{
    [SerializeField] GameObject _diamond;
    void Start()
    {
        Observer.AddListener("SpawnDiamond", spawnDiamond);
    }
    void OnDestroy()
    {
        Observer.RemoveListener("SpawnDiamond", spawnDiamond);
    }

    void spawnDiamond(object[] datas)
    {
        GameObject obj = Object_Pooling.Instance.GetPrefabs(_diamond);
        obj.transform.position = (Vector3)datas[0];
        obj.transform.position += new Vector3(0, 1, 0);
        obj.SetActive(true);
    }
}
