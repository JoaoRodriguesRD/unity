using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyMinion enemy_n1;
    public Vector2 SpawnPosition;
    void Start()
    {
        
    }

    void Update()
    {
        if(Time.frameCount % 10 == 0){
            Instantiate(enemy_n1, SpawnPosition, this.transform.rotation);
        }
        
    }
}
