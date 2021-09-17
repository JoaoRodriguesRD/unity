using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyMinion enemy_n1;
    public Vector2 SpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount % 10 == 0){
            Instantiate(enemy_n1, SpawnPosition, this.transform.rotation);
        }
        
    }
}
