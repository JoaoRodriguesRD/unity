using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    public float smooth;

    public float cameraXmin;
    public float cameraXmax;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // update suave
    void LateUpdate()
    {
        

        Vector3 following = new Vector3(player.position.x, transform.position.y,transform.position.z);

        if (following.x < cameraXmin)
            following.x = cameraXmin;
        if (following.x > cameraXmax)
            following.x = cameraXmax; 


        //O Lerp deixa mais suave a movimentacao de vetores
        transform.position = Vector3.Lerp(transform.position,following, smooth * Time.deltaTime);
    }
}
