using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomCtrl : MonoBehaviour, ITrap
{
    [SerializeField] private float _force = 20f;
    [SerializeField] private GameObject _vfxboom;
     
    void Update()
    {
        checkDrop();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int a = UnityEngine.Random.Range(1, 3);
            SoundController.Instance.SFXPlay("Explo" + a);
            Damage(other);
            Force(other);
            VFX(other);
        }        
    }

    void checkDrop()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2f))
        {
            if (hit.collider.CompareTag("Platform")) return;
            else
            {
                this.gameObject.SetActive(false);
            }
            
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
        this.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(DestroyBoom());
        
    }

    public void Damage(Collision others)
    {
        ITakeDamge _isCanTakeDmg = others.gameObject.GetComponent<ITakeDamge>();
        if(_isCanTakeDmg != null)   
        {
            _isCanTakeDmg.TakeDamage(others.gameObject.GetComponent<PlayerController>().Hp);
        }
    }

    IEnumerator DestroyBoom()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
