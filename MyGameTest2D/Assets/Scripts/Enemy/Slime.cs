using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Slime : MonoBehaviour
{
    [Header("Walking")]
    public float speed;
    public float walkTime;

    private float timer;
    private bool walkRight = true;

    public bool dying = false;

    [Header("life")]
    public int health;

    public int attack;

    private Rigidbody2D rig;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= walkTime)
        {
            timer = 0f;
            walkRight = !walkRight;
            

        }
        if (!dying)
        {
            if (walkRight)
            {
                transform.eulerAngles = new Vector2(0, 180);
                rig.velocity = Vector2.right * speed;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                rig.velocity = Vector2.left * speed;
            }

        }

    }

    public void Damage(int damage)
    {
        if (!dying)
        {
            health -= damage;
            anim.SetTrigger("hit");
        }
                

        
         if (health <= 0) {
            dying = true;
            anim.SetTrigger("die");
            Destroy(gameObject, 0.5f);
        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(attack);
        }
    }
}
