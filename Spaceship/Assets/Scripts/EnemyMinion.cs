using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : MonoBehaviour
{
    public int life = 10;
    public void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Esse inimigo foi atingido por: "+ collision.name);
        if(collision.gameObject.tag == "Bullet"){
            Debug.Log("Sofri dano!");
        }

    }
}
