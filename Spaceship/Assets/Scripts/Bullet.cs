using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Vector2 velocidade;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocidade;
        this.gameObject.tag= "Bullet";
    }

    // Update is called once per frame
    void Update(){
        rb.velocity = velocidade;
        if(transform.position.y > 30){
            Destroy(gameObject);
        }
    }

    public void bullet_setVelocity(Vector2 velocidade){
        this.velocidade = velocidade;
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }
        
    }


}
