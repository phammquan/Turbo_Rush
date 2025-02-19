using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCtrl : MonoBehaviour
{
   [SerializeField] private float _velocity;
   [SerializeField] private bool _right;

   private void Start()
   {
       if(!_right)
           _velocity *= -1;
   }

   void Update()
    {   
        this.transform.Rotate(Vector3.forward * _velocity * Time.deltaTime);
    }
}
