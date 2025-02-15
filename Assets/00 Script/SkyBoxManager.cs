using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxManager : MonoBehaviour
{
    [SerializeField] private float _skyspeed;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * _skyspeed);
    }
}
