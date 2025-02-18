using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCtrl : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.back, 200 * Time.deltaTime);        
    }
}
