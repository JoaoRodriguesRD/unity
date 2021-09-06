using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;
    public GameController gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //GameController.instance.UpdateCoin(coinValue);
            gm.UpdateCoin(coinValue);
            Destroy(gameObject);

        }
    }
}
