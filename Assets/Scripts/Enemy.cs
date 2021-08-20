using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Transform _transform;

    private Transform _playerTransform;

    [SerializeField] private float speed;

    private int _health = 5;

    public static event EventHandler EnemyKilled;

    [SerializeField] private GameObject gearPrefab;

    private float _gearDropChance = .5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
        {
            EnemyKilled?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);

            if (Random.Range(0f, 1f) <= _gearDropChance)
                Instantiate(gearPrefab, _transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        Vector2 playerPos = new Vector2(_playerTransform.position.x, _playerTransform.position.y);
        Vector2 lookDirection = playerPos - _rigidbody.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;

        Vector3 forwardDirection = _transform.up; //(0, 1, 0)
        _rigidbody.velocity = new Vector2(forwardDirection.x * speed, forwardDirection.y * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _health--;
        }
    }
}