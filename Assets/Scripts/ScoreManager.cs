using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float _enemyKilled;
    [SerializeField] private TMP_Text text_enemyKilled;

    void Start()
    {
        _enemyKilled = 0;
        Enemy.EnemyKilled += OnEnemyKilled;
    }

    private void Update()
    {
        text_enemyKilled.text = "Score : " + _enemyKilled.ToString();
    }

    void OnEnemyKilled(object sender, EventArgs e)
    {
        _enemyKilled++;
    }
}