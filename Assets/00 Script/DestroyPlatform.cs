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
        StartCoroutine(deActive());
    }

    IEnumerator deActive()
    {
        yield return new WaitForSeconds(5f);
        this.transform.parent.gameObject.SetActive(false);
    }
}