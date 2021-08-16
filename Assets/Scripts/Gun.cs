using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float coolDown = 1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float bulletForce;

    private bool _isFiring;
    private float _timeFromLastShoot = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) _isFiring = true;
        else if (Input.GetButtonUp("Fire1")) _isFiring = false;

        if (_timeFromLastShoot < coolDown) _timeFromLastShoot += Time.deltaTime;
        else if (_isFiring && _timeFromLastShoot >= coolDown)
        {
            Fire();
            _timeFromLastShoot = 0;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce((spawnPoint.up * bulletForce), ForceMode2D.Impulse);
    }
}