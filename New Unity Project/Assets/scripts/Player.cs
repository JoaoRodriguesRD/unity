using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float runSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        //pegar o componente presente no objeto para modificar
        rigidbody2d = GetComponent<Rigidbody2D>();
        //modificar a gravidade do componente Rigidbody2D
        rigidbody2d.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
   
    void move(){
        //pegar inputs 
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //modificar velocidade do rigidbody2d
        rigidbody2d.velocity = new Vector2(horizontal*runSpeed,vertical*runSpeed);
    }
}
