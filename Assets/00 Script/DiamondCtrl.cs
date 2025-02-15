using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCtrl : MonoBehaviour
{
    [SerializeField] GameObject VFX;

    private void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        checkParent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject vfx = Object_Pooling.Instance.GetPrefabs(VFX);
            vfx.transform.position = this.transform.position;
            vfx.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }
    void checkParent()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
        {
            if (hit.collider.CompareTag("Platform"))
            {
                this.transform.SetParent(hit.transform);
            }
        }
    }
}