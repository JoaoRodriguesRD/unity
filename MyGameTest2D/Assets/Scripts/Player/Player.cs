using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;
    public float jumpForce;

    public GameObject arrow;
    public Transform firePoint;

    private Rigidbody2D rig;
    private Animator anim;
    SpriteRenderer sprite;

    public GameController gm;

    private float movement;

    public bool isJumping = false;
    public bool doubleJump = false;

    private bool isFiring = false;

    private bool isInjured = false;
    private bool transparent = false;


    private int framesInjured = 0;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        //GameController.instance.UpdateLives(health);
        gm.UpdateLives(health);
    }

    // Update is called once per frame
    void Update()
    {
        
        Jump();
        BowFire();
        hurt();

        //sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b,0.5f); 


    }

    private void hurt()
    {
        if (isInjured)
        {
            framesInjured++;
            if (framesInjured >500)
            {
                framesInjured = 0;
                isInjured = false;

            }
            if (framesInjured%50 == 0) {
                if (transparent)
                {
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
                    transparent = false;

                }
                else
                {
                    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.1f);
                    transparent = true;
                }
            }

        }
        else
        {
            framesInjured = 0;

            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        // pressionar nada valor: 0 
        // pressionar direira valor maximo: 1
        // pressionar esquerda valor maximo: -1
        movement = Input.GetAxis("Horizontal");
        //Debug.Log(movement);

        //adiciona velocidade no eixo x, y
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);
        if (movement > 0)
        {
            if (!isJumping)
                anim.SetInteger("transition", 1);

            transform.eulerAngles = new Vector3(0, 0,0);
            

        }
        else if(movement < 0)
        {
            if (!isJumping)
                anim.SetInteger("transition", 1);

            transform.eulerAngles = new Vector3(0,180,0);
            

        }
        else if(!isJumping && !isFiring)
        {
            anim.SetInteger("transition", 0);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }
            else if(doubleJump)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0f, jumpForce/2), ForceMode2D.Impulse);
                doubleJump = false;

            }
            
            
        }
        

    }

    void BowFire()
    {
        StartCoroutine("Fire");
    }



    //CORROTINA
    // corrotina eh executada e animar o player, quando terminar a animacao de 1 segundo por exemplo: (WaitForSeconds(1f)), uma outra animacao pode ser colocada  
    IEnumerator Fire()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetInteger("transition", 3);
            isFiring = true;


            createArrow();

            yield return new WaitForSeconds(0.5f);
            
            //anim.SetInteger("transition", 0);
            isFiring = false;
            
        }
    }


    private void createArrow()
    {
        
        GameObject Arrow = Instantiate(arrow, firePoint.position, firePoint.rotation);

        if (transform.rotation.y == 0)
        {
            Arrow.GetComponent<Bow>().isright = true;
            Arrow.transform.eulerAngles = new Vector3(0,0,0);
        }
        if(transform.rotation.y == 180)
        {
            Arrow.GetComponent<Bow>().isright = false;
            Arrow.transform.eulerAngles = new Vector3(0, 180, 0);
        }

        

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // a layer 8 foi definida para ser o "ground"
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;

        }
        
    }

    public void Damage(int damage)
    {
        if (!isInjured)
        {
            health -= damage;
            GameController.instance.UpdateLives(health);
            anim.SetTrigger("hit");
            rig.velocity = new Vector2(rig.velocity.y, 10);
            isInjured = true;
        }
        
        /* if (transform.rotation.y == 0)
         {
             //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 1, transform.position.y, 0), 20 * Time.deltaTime);

             //rig.velocity = new Vector2(0, 10);
             //rig.AddForce(Vector2.up * 5, ForceMode2D.Force);
             Debug.Log("ataque esquerda");

         }
         if(transform.rotation.y == -1){
             //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 1, transform.position.y, 0), 20 * Time.deltaTime);
             Debug.Log("ataque direita");
             //rig.velocity = new Vector2(0, 10);
             //rig.AddForce(Vector2.up * 5, ForceMode2D.Force);
         }*/


        if (health<= 0 )
        {

        }
    }

    public void IncreaseLife(int value)
    {
        health += value;
        //GameController.instance.UpdateLives(health);
        gm.UpdateLives(health);
}
}
