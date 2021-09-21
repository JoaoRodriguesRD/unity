using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 velocidade;
    public Rigidbody2D rb;
    public Vector2 firstPosition;
    public GameObject player;
    public float lifetime = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        goToTarget();
        
    }
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        this.gameObject.tag= "EnemyBullet";
    }
    
    void Update()
    {
        Destroy(gameObject,lifetime);
    }

    /// <summary>
    /// Metodo para a bala rotacionar e ir em direcao ao player
    /// </summary>
    public void goToTarget(){
        firstPosition = transform.position;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(firstPosition);
        Vector3 target = player.transform.position;
        Vector2 offset = new Vector2(target.x - firstPosition.x,target.y-firstPosition.y);
        float angulo = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,angulo);
        rb.velocity = transform.right * 10f;
    }
}
