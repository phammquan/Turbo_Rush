using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    private Rigidbody rigiParent;

    private void Awake()
    {
        rigiParent = GetComponentInParent<Rigidbody>();
    }

    public void OnEnable()
    {
        rigiParent.useGravity = false;
        rigiParent.isKinematic = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fallDown();
        }
    }

    public void fallDown()
    {
        rigiParent.useGravity = true;
        rigiParent.isKinematic = false;
        if(!this.transform.parent.gameObject.activeSelf) return;
        StartCoroutine(deActive());
    }

    IEnumerator deActive()
    {
        yield return new WaitForSeconds(2f);
        this.transform.parent.gameObject.SetActive(false);
    }
}