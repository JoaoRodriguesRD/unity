using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : Enemy 
{
    public EnemyBullet bullet_enemy;
    private int frame = 0;
    public int fireRate = 200;

    void Start()
    {
        setLife(1);
        setSpeed(0.01f);
        rigidbody_enemy = GetComponent<Rigidbody2D>();
        
    }

    void Awake()
    {
        this.gameObject.tag = "Enemy";
    }

    void Update()
    {
        deathLogic();
        walk();
        enemyFire();
    }
    public void enemyFire(){
        frame++;
        if(frame > fireRate){
            frame = 0;
        }
        if(frame == 10){
            Instantiate(bullet_enemy, this.transform.position, this.transform.rotation);
        }
        
    }

    public void walk(){
        float velocity = -getSpeed();
        //rigidbody_enemy.velocity = new Vector2( Mathf.Sin(transform.position.y), velocity);
        transform.position = new Vector2(Mathf.Sin(transform.position.y),transform.position.y + velocity);    
    }


}
