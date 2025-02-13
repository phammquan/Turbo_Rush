using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject _platform;
    [SerializeField] private int colums;
    [SerializeField] private int rows;
    Stack<GameObject> platforms = new Stack<GameObject>();
    public Vector3 sz;
    float size = 0;
    float size1 = 0;
    private void Start()
    {
        
        sz = _platform.transform.localScale;
        SpawnPlatform();
        StartCoroutine(StartDes());
    }

    void SpawnPlatform()
    {
        for (int i = 0; i < colums; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject _temp;
                _temp = Instantiate(_platform, new Vector3(size, 0, size1), Quaternion.identity);
                _temp.transform.SetParent(this.transform);
                
                if (size == rows * sz.z - 2)
                {
                    size = 0;
                }
                else
                {
                    if (size == -(colums * sz.x - 2))
                    {
                        size = 0;
                    }
                    else
                    {
                        size -= sz.z;
                    }
                }
                platforms.Push(_temp);
            }
            size1 += sz.x;
        }
    }
    IEnumerator StartDes()
    {
        yield return new WaitForSeconds(5f);
        InDestroy();
    }
    IEnumerator InDestroy()
    {
        while (platforms.Count > 0)
        {
            GameObject temp = platforms.Pop();
            temp.transform.GetChild(0).GetComponent<DestroyPlatform>().fallDown();
            yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        }
    }
}
