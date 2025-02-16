using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPlatform : MonoBehaviour
{
    [SerializeField] GameObject _platform;
    [SerializeField] GameObject _platformTrap;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _diamond;
    [SerializeField] GameObject _trap;

    private Vector3 lastPos;

    private Vector3 _size;
    private Vector3 _sizeTrap;

    [SerializeField] private float _time;
    private float checkSpawn;
    private int countDiamond;
    public int count;
    private bool checkTrap = false;

    // Start is called before the first frame update
    void Start()
    {
        checkSpawn = _time;
        lastPos = _platform.transform.position;
        _size = _platform.transform.localScale;
        _sizeTrap = _platformTrap.transform.localScale;
    }

    void Update()
    {
        checkSpawn -= Time.deltaTime;

        if (checkSpawn <= 0 && _player.GetComponent<PlayerController>().gameOver == false)
        {
            Spawn();
            checkSpawn = _time;
        }
    }

    void Spawn()
    {
        int rand = Random.Range(0, 6);
        int rand1 = Random.Range(0, 15);
        // if (countDiamond == count)
        // {
        //     countDiamond = 0;
        //     Observer.Notify("SpawnTrap", lastPos);
        // }
        // else
        // {
        if (rand1 <= 3 && !checkTrap)
        {
            Observer.Notify("SpawnDiamond", lastPos);
            countDiamond++;
        }

        // }
        if (rand <= 3)
        {
            SpawnLeft();
        }
        else
        {
            SpawnRight();
        }
    }

    void SpawnLeft()
    {
        Vector3 pos = lastPos;
        GameObject g;

        if (countDiamond == count)
        {
            pos.z += (_sizeTrap.z * 0.5f) + (_size.z * 0.5f);
            g = Object_Pooling.Instance.GetPrefabs(_platformTrap);
            g.transform.position = pos;
            lastPos = g.transform.position;
            checkTrap = true;
            countDiamond = 0;
            if (g.transform.childCount <= 2)
            {
                Observer.Notify("SpawnTrap", lastPos);
            }
        }
        else
        {
            pos.z += _size.z;
            g = Object_Pooling.Instance.GetPrefabs(_platform);
            g.transform.position = pos;
            if (checkTrap)
            {
                g.transform.position += new Vector3(0, 0, 0.5f);
                checkTrap = false;
            }

            lastPos = g.transform.position;
        }

        g.transform.rotation = Quaternion.identity;
        g.SetActive(true);
    }

    void SpawnRight()
    {
        Vector3 pos = lastPos;
        GameObject g;
        if (countDiamond == count)
        {
            pos.x += (_sizeTrap.x * 0.5f) + (_size.x * 0.5f);
            g = Object_Pooling.Instance.GetPrefabs(_platformTrap);
            g.transform.position = pos;
            lastPos = g.transform.position;
            checkTrap = true;
            countDiamond = 0;
            if (g.transform.childCount <= 2)
            {
                Observer.Notify("SpawnTrap", lastPos);
            }
        }
        else
        {
            pos.x += _size.x;
            g = Object_Pooling.Instance.GetPrefabs(_platform);
            g.transform.position = pos;
            if (checkTrap)
            {
                g.transform.position += new Vector3(0.5f, 0, 0);
                checkTrap = false;
            }

            lastPos = g.transform.position;
        }

        g.transform.rotation = Quaternion.identity;
        g.SetActive(true);
    }
}