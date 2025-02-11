using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    private void OnEnable()
    {
        StartCoroutine(DeActive());
    }
    
    IEnumerator DeActive()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
