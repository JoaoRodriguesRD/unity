using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int life;
    private float speed;
    public Rigidbody2D rigidbody_enemy;



    public void deathLogic(){
        if(life <= 0){
            Destroy(gameObject);
        }
    }
    public void walk(){
        rigidbody_enemy.velocity = new Vector2(0,- speed);
    }

    public void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Esse inimigo foi atingido por: "+ collision.name);
        if(collision.gameObject.tag == "Bullet"){
            Debug.Log("Sofri dano!");
            life --;
        }
    }

    public int getLife(){
        return life;
    }

    public float getSpeed(){
        return speed;
    }

    public void setLife(int life){
        this.life = life;
    }
    public void setSpeed(float speed){
        this.speed = speed;

    }

}
