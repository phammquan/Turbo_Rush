using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fallDown();
        }
       
    }

    void fallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);
        
    }
}
