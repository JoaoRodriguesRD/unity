using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : Enemy 
{
    void Start()
    {
        life = 10;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        deathLogic();
        
    }



}
