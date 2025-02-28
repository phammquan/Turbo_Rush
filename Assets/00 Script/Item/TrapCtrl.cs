using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCtrl : MonoBehaviour, ITrap
{
    [SerializeField] float _velocity;
    [SerializeField] GameObject _vfx;
    [SerializeField] private float _force;
    private int _damage = 10;

    private void OnEnable()
    {
        this.transform.SetParent(null);
    }

    void Update()
    {
        this.transform.Rotate(Vector3.up * _velocity * Time.deltaTime);
        checkParent();
    }

    void checkParent()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
        {
            if (hit.collider.CompareTag("Platform"))
            {
                this.transform.SetParent(hit.transform);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundController.Instance.SFXPlay("Hit");
            Damge(other);
            Force(other);
            VFX(other);
            
        }        
    }


    public void Force(Collision others)
    {
        
        Rigidbody playerRb = others.gameObject.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            Vector3 direction = others.contacts[0].point - transform.position;
            direction.y = 0; 
            direction.Normalize();
            
            playerRb.AddForce(direction * _force, ForceMode.Impulse);
        }
    }

    public void VFX(Collision others)
    {
        foreach (ContactPoint contact in others.contacts)
        {
            Vector3 collisionPoint = contact.point;
            GameObject vfxInstance = Object_Pooling.Instance.GetPrefabs(_vfx);
            if (vfxInstance != null)
            {
                vfxInstance.transform.position = collisionPoint;
                vfxInstance.SetActive(true);
            }
            else
            {
                Debug.LogWarning("VFX instance is null. Check Object Pooling setup.");
            }
        }
    }

    public void Damge(Collision others)
    {
        ITakeDamge _isCanTakeDmg = others.gameObject.GetComponent<ITakeDamge>();
        if(_isCanTakeDmg != null)   
        {
            _isCanTakeDmg.TakeDamage(_damage);
        }
    }
}