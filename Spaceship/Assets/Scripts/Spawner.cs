using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab_enemy;
    public Vector2 SpawnPosition;
    public int rate;
    private int framecount=0;
    void Start()
    {
        rate = 2000;
        SpawnPosition = this.transform.position;

    }

    void Update()
    {
        framecount++;
        if(framecount > rate){
            framecount = 0;
            Instantiate(prefab_enemy, SpawnPosition, this.transform.rotation);
        }
    }
}
