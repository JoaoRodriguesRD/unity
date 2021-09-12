using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : MonoBehaviour
{
    public int life = 10;
    void OnCollisionEnter2D(){
        Debug.Log(" a");
    }
    void OnCollisionStay2D(){
            //Output the message
            Debug.Log(" b");
        
    }
}
