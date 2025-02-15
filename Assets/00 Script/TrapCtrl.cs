using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCtrl : MonoBehaviour
{
    [SerializeField] float _velocity;

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
    
}