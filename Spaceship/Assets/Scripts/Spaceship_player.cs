using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_player : MonoBehaviour
{
    public float horizontal;
    public float runSpeed = 10f;
    public Rigidbody2D rb;

    public Bullet bullet;

    public float shootSpeed = 5f;
    void Start()
    {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        //definir a tag Player, foi usada para referenciar Player em Inimigo, assim o inimigo atira no angulo certo
        //OBS: Se nao colocar em Awake pode dar erro quando carregar o jogo, pois outras classes buscarao o objeto com a tag Player
        this.gameObject.tag= "Player";
    }


    void Update()
    {
        controlHorizontal();
        fire();
        
    }
    /// <summary>
    /// O player so se move na horizontal, ficando na posicao inferior da tela o tempo todo
    /// </summary>
    public void controlHorizontal(){
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal*runSpeed,0);
    }
    /// <summary>
    /// Metodo para atirar com o botao espaco
    /// </summary>
    public void fire(){
        if (Input.GetKeyDown("space"))
        {
            bullet.bullet_setVelocity(new Vector2(0,1) * shootSpeed);
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }
    }
}
