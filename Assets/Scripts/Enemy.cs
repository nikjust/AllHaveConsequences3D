using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;
    public float Defense;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void DealDamage(int damage)
    {
        if (damage > Defense)
        {
            Health -= damage;
        }
    }
}
