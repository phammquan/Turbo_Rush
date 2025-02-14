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

    void spawnTrap(object[] datas)
    {
        GameObject objTrap = Object_Pooling.Instance.GetPrefabs(_trap);
        objTrap.transform.position = (Vector3)datas[0];
        objTrap.transform.position += new Vector3(0, 0.6f, 0);
        objTrap.SetActive(true);
        // GameObject _plf = Object_Pooling.Instance.GetPrefabs(_platform); 
        // Vector3 _trapPos = objTrap.transform.position;
        // int rand = Random.Range(0, 2);
        // if (rand == 0)
        // {
        //     _trapPos.z -= _size.z;
        //     Debug.Log("SpawnTrap");
        // }
        // else
        // {
        //     _trapPos.x -= _size.x;
        // }
        // _plf.transform.position = _trapPos;
        
    }
}
