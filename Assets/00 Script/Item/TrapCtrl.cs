using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCtrl : MonoBehaviour
{
    [SerializeField] float _velocity;
    [SerializeField] GameObject _vfx;

    private void OnEnable()
    {
        this.transform.SetParent(null);
    }

    void Update()
    {
        this.transform.Rotate(Vector3.up * _velocity * Time.deltaTime);
        checkParent();
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint contact in other.contacts)
            {
                Vector3 collisionPoint = contact.point;
                GameObject vfxInstance = Object_Pooling.Instance.GetPrefabs(_vfx);
                if (vfxInstance != null)
                {
                    vfxInstance.transform.position = collisionPoint;
                    vfxInstance.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("VFX instance is null. Check Object Pooling setup.");
                }
            }
        }        
    }
}