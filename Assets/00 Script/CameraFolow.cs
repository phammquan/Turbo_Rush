using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Vector3 _offset;
    [SerializeField] private float rateLerp;
    public bool gameOver;

    void Start()
    {
        
        _offset = transform.position - _player.transform.position;    
    }

    void Update()
    {
        
        if(!_player.GetComponent<PlayerController>().gameOver)
        {
            CameraMove();
        }
        
    }

    void CameraMove()
    {
        Vector3 pos = this.transform.position;
        Vector3 targetPos = _player.transform.position + _offset;
        pos = Vector3.Lerp(pos, targetPos, rateLerp * Time.deltaTime);
        this.transform.position = pos;
    }
}
