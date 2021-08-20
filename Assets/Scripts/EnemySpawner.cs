using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint1;

    [SerializeField] private Transform spawnPoint2;

    [SerializeField] private float spawnCooldown;

    [SerializeField] private GameObject enemyPrefab;

    private float _timeFromlastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        _timeFromlastSpawn = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeFromlastSpawn <= spawnCooldown) _timeFromlastSpawn += Time.deltaTime;


        float randomX = Random.Range(spawnPoint1.position.x, spawnPoint2.position.x);

        if (_timeFromlastSpawn >= spawnCooldown)
        {
            Instantiate(
                enemyPrefab,
                new Vector3(randomX, spawnPoint1.position.y, 0),
                Quaternion.identity);
            _timeFromlastSpawn = 0;
        }
    }
}