using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigi;
    [SerializeField] float _speed ;
    private Vector3 _direction;
    private bool right = true;
    [SerializeField] float _speedRotation = 100f;
    [Space] public bool gameOver;
    private bool gameRuning = false;

    void Start()
    {
        gameOver = false;
        _rigi = GetComponent<Rigidbody>();
        _direction = transform.forward;
    }

    void Update()
    {
        if (Input.touchCount > 0 && !gameOver)
        {
            gameRuning = true;
            Observer.Notify("ContinueGame", gameRuning);
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
        Move();
        checkGameOver();
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
        gameOver = (raysHitPlatform == 0);
        Observer.Notify("GameOver", gameOver);
    }
}