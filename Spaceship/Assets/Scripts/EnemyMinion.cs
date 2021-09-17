using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : Enemy 
{
    void Start()
    {
        setLife(1);
        setSpeed(0.01f);
        rigidbody_enemy = GetComponent<Rigidbody2D>();
        this.gameObject.tag = "Enemy";
    }

    void Update()
    {
        deathLogic();
        walk();
        enemyFire();
    }
    public void enemyFire(){
        GameObject player = findSpaceship_player();
        Debug.Log("position player: "+ player.transform.position);
        bullet_enemy = new Bullet();
        bullet_enemy.bullet_setVelocity(player.transform.position);
        Instantiate(bullet_enemy, this.transform.position, this.transform.rotation);

    }

    public void walk(){
        float velocity = -getSpeed();
        //rigidbody_enemy.velocity = new Vector2( Mathf.Sin(transform.position.y), velocity);
        transform.position = new Vector2(Mathf.Sin(transform.position.y),transform.position.y + velocity);
        Debug.Log("Deltatime: " + Time.deltaTime);
        Debug.Log("time: " + Time.time);
        Debug.Log("Time Framecount: " + Time.frameCount);
        Debug.Log("----------------------------");
        
    }


}
