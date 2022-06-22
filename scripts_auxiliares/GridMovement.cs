using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GridMovement : MonoBehaviour
{
    public bool isMoving;
    public float timeToMove = 0.2f;
    public Vector3 origem,destino;

    public Tilemap background;
    public Tilemap wall;
    void Start()
    {
        
    }
    void Awake(){
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && !isMoving){

            MovePlayerLogic(Vector3.up);
        }
        if(Input.GetKey(KeyCode.A) && !isMoving){
            MovePlayerLogic(Vector3.left);
        }
        if(Input.GetKey(KeyCode.S) && !isMoving){
            MovePlayerLogic(Vector3.down);
        }
        if(Input.GetKey(KeyCode.D) && !isMoving){
            MovePlayerLogic(Vector3.right);
        }
    }

    private void MovePlayerLogic(Vector3 direction)
    {
        
        if(canMove(direction)){
            
            StartCoroutine(Move(direction));
        }else{
            
            DontMove(direction);
        }
        
    }

    private void DontMove(Vector3 direction)
    {
        Debug.Log("Não pode mover para: "+ direction);
    }

    private IEnumerator Move(Vector3 direction)
    {
        Debug.Log("Pode mover para+ " +direction);
        isMoving = true;
        float elapseTime = 0;
        origem = transform.position;
        destino = origem + direction;

        while(elapseTime < timeToMove){
            transform.position = Vector3.Lerp(origem,destino, elapseTime/timeToMove);
            elapseTime += Time.deltaTime;
            yield return null;
        }
        transform.position = destino;
        isMoving = false;
    }

    private bool canMove(Vector3 direction){
        Vector3Int grigpos = background.WorldToCell(transform.position + direction);
        if(wall.HasTile(grigpos)){
            return false;
        }
        return true;
    }
}
