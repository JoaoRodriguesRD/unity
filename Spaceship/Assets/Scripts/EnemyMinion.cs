using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : Enemy 
{
    void Start()
    {
        setLife(10);
        setSpeed(1f);
        rigidbody_enemy = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        deathLogic();
        walk();
    }



}
