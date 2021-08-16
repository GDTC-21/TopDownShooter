using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Vector2 _movement;
    private Vector2 _mousePos;
    [SerializeField] private float speed;

    [SerializeField] private Camera cam;

    public static event EventHandler GearCollected;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // update 120fps -> update 120 kali 
    void Update()
    {
        //getaxis -> antara -1 <-> 1
        _movement.x = Input.GetAxisRaw("Horizontal"); // antara -1, 0, 1
        _movement.y = Input.GetAxisRaw("Vertical");
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // update 60fps -> update 60 kali
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_movement.x * speed, _movement.y * speed);

        Vector2 lookDirection = _mousePos - _rigidbody.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;

        _rigidbody.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Gear"))
        {
            GearCollected?.Invoke(this, EventArgs.Empty);
        }
    }
}