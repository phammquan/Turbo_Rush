using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ITakeDamge
{
    [SerializeField] private int _hp;
    private int _hpcheck;
    [SerializeField] float _speed;
    private Vector3 _direction;
    private bool right = true;
    [SerializeField] float _speedRotation;
    [Space] public bool gameOver;
    private bool _isGrounded;
    private SOPlayerData _playerData;
    [SerializeField] GameObject _explosion;
    [SerializeField] GameObject _burning;


    void Awake()
    {
        Observer.AddListener("GetData", UpdateDataPlayer);
        
    }

    private void OnDestroy()
    {
        Observer.RemoveListener("GetData", UpdateDataPlayer);
    }

    private void Start()
    {
        _isGrounded = true;
        gameOver = false;
        _direction = transform.forward;
    }

    private void UpdateDataPlayer(object[] obj)
    {
        _playerData = (SOPlayerData)obj[0];
        _speed = _playerData.Speed;
        _hp = _playerData.Hp;
        Observer.Notify("UpdateHP", _hp);
        _hpcheck = _hp/2;
        _speedRotation = _playerData.SpeedRotation;

        
    }
    void Update()
    {
        InputControler();
        Move();
        if(_isGrounded)
            checkGameOver();
    }

    void InputControler()
    {
        if (Input.touchCount > 0 && !gameOver)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary)
            {
                changeDir();
            }
            if (touch.position.x < Screen.width / 2)
            {
                right = false;
            }
            else
            {
                right = true;
            }
        }
    }

    void Move()
    {
        if (_direction != Vector3.zero)
        {
            _direction = transform.forward;
            this.transform.position += _direction * _speed * Time.deltaTime;
        }
    }
    
    void changeDir()
    {
        Quaternion rotation = this.transform.rotation;
        float newAngle = rotation.eulerAngles.y + _speedRotation * Time.deltaTime * (right ? 1 : -1);
        rotation.eulerAngles = new Vector3(0, newAngle, 0);
        this.transform.rotation = rotation;
    }

    public void checkGameOver()
    {
        int numRaysX = 5;
        int numRaysZ = 9;
        float checkDistance = 1f;
        int raysHitPlatform = 0;

        for (int i = 0; i < numRaysX; i++)
        {
            for (int j = 0; j < numRaysZ; j++)
            {
                Vector3 offset = new Vector3(i * 0.2f - (numRaysX / 2) * 0.2f, 0, j * 0.2f - (numRaysZ / 2) * 0.2f);
                Vector3 origin = transform.position + offset;
                if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, checkDistance))
                {
                    if (hit.collider.tag == "Platform")
                    {
                        raysHitPlatform++;
                    }
                }
            }
        }
        _isGrounded = !(raysHitPlatform == 0);
        if(!_isGrounded)
        {
            gameOver = true;
            StartCoroutine(DelayExplosion());
            Observer.Notify("GameOver", gameOver);
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(_hpcheck);
        if(_hp > 0 && _isGrounded)
        {
            _hp -= damage;
            Observer.Notify("UpdateHP", _hp);
            if(_hp <= _hpcheck)
                _burning.SetActive(true);
            if(_hp <= 0)
            {
                StartCoroutine(DelayExplosion());
                _hp = 0;
                Observer.Notify("UpdateHP", _hp);
                gameOver = true;
                Observer.Notify("GameOver", gameOver);
            }
        }
    }
    IEnumerator DelayExplosion()
    {
        
        yield return new WaitForSeconds(.5f);
        _explosion.SetActive(true);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}