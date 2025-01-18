using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public void OnEnable()
    {
        GetComponentInParent<Rigidbody>().useGravity = false;
        GetComponentInParent<Rigidbody>().isKinematic = true;
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
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        StartCoroutine(deActive());
    }
    IEnumerator deActive(){
        yield return new WaitForSeconds(1f);
        this.transform.parent.gameObject.SetActive(false);
    }
}
