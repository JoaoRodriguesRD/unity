using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Vector2 velocidade;
    public Rigidbody2D rb;
    public float lifetime = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocidade;
        this.gameObject.tag = "Bullet";
    }

    void Update()
    {
        rb.velocity = velocidade;
        Destroy(gameObject, lifetime);

    }

    /// <summary>
    /// A velocidade da bala eh definida na criacao dela
    /// </summary>
    public void bullet_setVelocity(Vector2 velocidade)
    {
        this.velocidade = velocidade;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }


}
