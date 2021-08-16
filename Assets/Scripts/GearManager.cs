using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    private float _gearCount;
    [SerializeField] private TMP_Text text_gearCount;

    void Start()
    {
        _gearCount = 0;
        Player.GearCollected += OnGearCollected;
    }

    private void Update()
    {
        text_gearCount.text = "Gear : " + _gearCount.ToString();
    }

    void OnGearCollected(object sender, EventArgs e)
    {
        _gearCount++;
    }
}