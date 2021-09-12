using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life;
    public float speed;
    public Rigidbody2D rigidbody;

    void Start()
    {
        
    }

    void Update()
    {
        
    }



    public void deathLogic(){
        if(life <= 0){
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Esse inimigo foi atingido por: "+ collision.name);
        if(collision.gameObject.tag == "Bullet"){
            Debug.Log("Sofri dano!");
            life --;
        }

    }
}
