using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCtrl : MonoBehaviour
{
    [SerializeField] GameObject VFX;
    private GameObject vfx; 
    private void Start()
    {
        vfx = Object_Pooling.Instance.GetPrefabs(VFX);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("trigger");
            if (vfx != null)
            {
                vfx.transform.position = this.transform.position;
                vfx.SetActive(true);

            }
            else
            {
                Debug.Log("null");
            }
            this.gameObject.SetActive(false);
        }
    }
}
