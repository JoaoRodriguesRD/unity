using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : Enemy 
{
    void Start()
    {
        life = 10;
        speed = 1f;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        deathLogic();
        
        rigidbody.velocity = new Vector2(0,- speed);
    }



}
