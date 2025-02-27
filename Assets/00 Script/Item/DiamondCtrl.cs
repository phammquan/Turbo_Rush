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
        checkDrop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundController.Instance.SFXPlay("Collect");
            Observer.Notify("DiamondCount");
            GameObject vfx = Object_Pooling.Instance.GetPrefabs(VFX);
            vfx.transform.position = this.transform.position;
            vfx.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    void checkDrop()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2f))
        {
            if (hit.collider.CompareTag("Platform")) return;
            else
            {
                this.gameObject.SetActive(false);
            }
            
        }
    }
}