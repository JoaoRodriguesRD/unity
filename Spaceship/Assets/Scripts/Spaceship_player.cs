using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_player : MonoBehaviour
{
    public float horizontal;
    public float runSpeed = 10f;
    public Rigidbody2D rb;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
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
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }
    }
}
