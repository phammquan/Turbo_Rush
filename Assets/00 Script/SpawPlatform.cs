using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPlatform : MonoBehaviour
{
    [SerializeField] GameObject _platform;
    [SerializeField] GameObject _player;
    

    private Vector3 lastPos;

    private Vector3 _size;
    
    [SerializeField] private float _time;
    private float checkSpaw;

    // Start is called before the first frame update
    void Start()
    {
        checkSpaw = _time;
        lastPos = _platform.transform.position;
        _size = _platform.transform.localScale;
    }

    void Update()
    {
        checkSpaw -= Time.deltaTime;
        
        if (checkSpaw <= 0 && _player.GetComponent<PlayerController>().gameOver == false)
        {
            Spaw();
            checkSpaw = _time;
        }
    }

    void Spaw()
    {
        int rand = Random.Range(0, 6);
        if (rand <= 3)
        {
            SpawLeft();
        }
        else
        {
            SpawRight();
        }
    }

    void SpawLeft()
    {
        Vector3 pos = lastPos;
        pos.z += _size.z;
        Instantiate(_platform, pos, Quaternion.identity);
        lastPos = pos;
    }

    void SpawRight()
    {
        Vector3 pos = lastPos;
        pos.x += _size.x;
        Instantiate(_platform, pos, Quaternion.identity);
        lastPos = pos;
    }
}