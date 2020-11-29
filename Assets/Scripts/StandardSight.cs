using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardSight : MonoBehaviour
{

    public float sightDist;
    //Reference to the dialog
    public TextAsset myDialog;

    //If gameObject has patroller, to disable it when sighted
    public bool hasPatroller = true;

    //If you want player to respawn
    public bool playerRespawn = true;
    public Transform respawnPosition;

    private Vector3 prevPos = Vector2.zero;

    public float raycastOffset = 1.0f;

    private bool canDetect = true;

    void Start() {
        Physics2D.queriesStartInColliders = false; //to make sure it doesn't detect itself with the raycast
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 direction = GameObject.Find("Utils").GetComponent<Utilities>().FromWhichDirection(prevPos, transform.position);

        Vector3 raycastStart = transform.position;
        raycastStart.y += raycastOffset; //every human is 2 big, so halfway up second tile 

        RaycastHit2D hitInfo = Physics2D.Raycast(raycastStart, direction, sightDist);  //where the ray should start, which direction it should have and the max distance 
        if (hitInfo.collider != null) {

            Debug.DrawLine(raycastStart, hitInfo.point, Color.red); //hitInfo.point is position of collision of raycast

            if (hitInfo.collider.CompareTag("MainCharacter")) {
                if (canDetect) {
                    canDetect = false;
                    Invoke("CanDetect",2.0f);
                    DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
                    dialogManager.Talk(myDialog, StartDialog, EndDialog);

                }
            }
        } else {
            Vector3 drawLineStart = transform.position;
            drawLineStart.y += raycastOffset = 1.0f;
            Debug.DrawLine(raycastStart, drawLineStart + direction * sightDist, Color.green);
        }


        prevPos = transform.position;
    }


    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        if (hasPatroller) {
            GetComponent<Patroller>().TogglePausePatrol(true);
        }
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        if (hasPatroller) {
            GetComponent<Patroller>().TogglePausePatrol(false);
        }

        if (playerRespawn) {
            GameObject.Find("Player").GetComponent<Transform>().position = respawnPosition.position;
        }
        
    }


    public void CanDetect() {
        canDetect = true;
    }
}


