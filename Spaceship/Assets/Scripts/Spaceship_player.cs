using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_player : MonoBehaviour
{
    public float horizontal;
    public float runSpeed = 10f;
    public Rigidbody2D rb;

    public Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            //definir a tag Player, foi usada para referenciar Player em Inimigo, assim o inimigo atira no angulo certo
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        this.gameObject.tag= "Player";
    }

    // Update is called once per frame
    void Update()
    {
        controlHorizontal();
        fire();
        
    }
    public void controlHorizontal(){
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal*runSpeed,0);
    }
    public void fire(){
        if (Input.GetKeyDown("space"))
        {
            bullet.bullet_setVelocity(new Vector2(1,1));
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }
    }
}
