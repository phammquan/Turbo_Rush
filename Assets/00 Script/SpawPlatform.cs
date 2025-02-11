using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPlatform : MonoBehaviour
{
    [SerializeField] GameObject _platform;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _diamond;

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
        GameObject g = Object_Pooling.Instance.GetPrefabs(_platform);
        g.transform.position = pos;
        g.SetActive(true);
        lastPos = pos;
        SpawDiamond(g);
    }

    void SpawRight()
    {
        Vector3 pos = lastPos;
        pos.x += _size.x;
        GameObject g = Object_Pooling.Instance.GetPrefabs(_platform);
        g.transform.position = pos;
        g.SetActive(true);
        lastPos = pos;
        SpawDiamond(g);
    }

    void SpawDiamond(GameObject _platformSpaw)
    {
        int rand = Random.Range(0, 15);
        if (rand <= 3)
        {
            GameObject obj = Object_Pooling.Instance.GetPrefabs(_diamond);
            obj.transform.position = _platformSpaw.transform.position;
            obj.transform.position += new Vector3(0, 1, 0);
            obj.SetActive(true);
        }
    }
}