using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCount : MonoBehaviour
{
    void Update()
    {
        Debug.Log("FPS: " + (1.0f / Time.deltaTime));
    }

}