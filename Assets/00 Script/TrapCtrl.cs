using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCtrl : MonoBehaviour
{
    [SerializeField] float _velocity;
    void Update()
    {
     this.transform.Rotate(Vector3.up * _velocity * Time.deltaTime);   
    }
}
