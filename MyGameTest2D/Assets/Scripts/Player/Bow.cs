using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float speed = 12;
    public int damage;
    private Rigidbody2D rig;
    public bool isright;



    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        //destroi depois de 2 segundos
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isright)
        {
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            rig.velocity = Vector2.left * speed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Slime>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
