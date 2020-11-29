using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps; //to work with tilemaps

public class GroundTrigger_Ladder : MonoBehaviour
{

    public bool isLadder = false;
    public bool isIce = false; 
    public bool isMine = false;


    public Tilemap Tilemap;
    public ParticleSystem iceParticle;
    private GameObject TilemapGO;


    void Start () {  
        TilemapGO=gameObject;  

        //Instantiate if ice, particlesystem on it     
        if (isIce) {
            Vector3 tilePosition;         
            Vector3Int coordinate = new Vector3Int(0, 0, 0);         
            for (int i = 0; i < Tilemap.size.x; i++) {             //loop over every tile coordinate
                for (int j = -100; j < Tilemap.size.y; j++) {     //kind of hacky to start y at -100. But basically adjust to whatever you need.            
                    coordinate.x = i; coordinate.y = j;       
                    TileBase tempTile = Tilemap.GetTile(coordinate);  //see if we have a tile there
                    if (tempTile) { //if we do, spawn effect there
                        tilePosition = Tilemap.CellToWorld(coordinate);   
                        ParticleSystem newEffect = Instantiate(iceParticle, tilePosition, Quaternion.identity);   
                        newEffect.transform.parent = TilemapGO.transform;       
                    }              
                }         
            }    
        }   
   } 



    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.name == "PlayerFeet") {

            if (isLadder) {
                other.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().moveSpeed = 5.0f;
                other.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().isOnLadder = false;
                //other is player feet. the transform contains info about parent/child objects. Hence the long thingy
            }

            if (isIce) {
                other.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().isOnIce = false;
            }
            
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.name == "PlayerFeet") {

            if (isLadder) {
                other.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().moveSpeed = 2.0f;
                other.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().isOnLadder = true;
                other.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().animator.SetInteger("direction", 1);
            }

            if (isIce) {
                other.gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().isOnIce = true;

            }
        }

    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "PlayerFeet") {

            if (isMine) {

            }




        }

    }

}
