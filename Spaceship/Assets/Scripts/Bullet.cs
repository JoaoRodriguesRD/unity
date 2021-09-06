using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int secondsToDestroy = 5;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,speed);
    }

}
