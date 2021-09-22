using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab_enemy;
    public Vector2 SpawnPosition;
    void Start()
    {

    }

    void Update()
    {
        if(Time.frameCount % 2 == 0){
            Instantiate(prefab_enemy, SpawnPosition, this.transform.rotation);
        }
        
    }
}
