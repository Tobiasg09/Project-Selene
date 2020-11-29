using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScientistSight : MonoBehaviour
{
    public float sightDist;
    //Reference to the dialog
    public TextAsset myDialog;

    //If gameObject has patroller, to disable it when sighted
    public bool hasPatroller = true;

    //If you want player to respawn
    public bool playerRespawn = true;

    //+- the direction that you want chemist to look
    public float angleFlex = 45.0f;

    private Vector3 prevPos = Vector2.zero;
    private Vector3 prevViableDirection = Vector3.zero;

    public float raycastOffset = 1.0f;

    public GameObject chapter3;

    private bool canDetect = true;

    void Start() {
        Physics2D.queriesStartInColliders = false; //to make sure it doesn't detect itself with the raycast
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 direction = GameObject.Find("Utils").GetComponent<Utilities>().FromWhichDirection(prevPos, transform.position);

        //This deals with chemists standing still. If stand still, then use previous directoin that was correct.
        if (direction == Vector3.zero) {
            direction = prevViableDirection;
        } else {
            prevViableDirection = direction;
        }


        Vector3 raycastStart = transform.position;
        raycastStart.y += raycastOffset; //every human is 2 big, so halfway up second tile 

        //Basically, every frame choose a random angle within direction - angleflex and directoin + angleflex.
        //done so as to give illusion of looking in a cone.
        float raycastBaseAngle = GameObject.Find("Utils").GetComponent<Utilities>().Vector2Angle((Vector2)direction); //find angle of direction
        float directionAngle = Random.Range(raycastBaseAngle-angleFlex, raycastBaseAngle+angleFlex); //Choose random angle from range
        Vector3 directionRaycast = (Vector3) GameObject.Find("Utils").GetComponent<Utilities>().Angle2Vector(directionAngle); //Change back to vector3


        RaycastHit2D hitInfo = Physics2D.Raycast(raycastStart, directionRaycast, sightDist);  //where the ray should start, which direction it should have and the max distance 
        if (hitInfo.collider != null) {

            Debug.DrawLine(raycastStart, hitInfo.point, Color.red); //hitInfo.point is position of collision of raycast

            if (hitInfo.collider.CompareTag("MainCharacter")) {
                if (canDetect) {
                    if (GameObject.Find("Player").GetComponent<PlayerMovement>().detected == false) {
                        GameObject.Find("Player").GetComponent<PlayerMovement>().detected = true;
                        canDetect = false;
                        Invoke("CanDetect",5.0f);
                        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
                        dialogManager.Talk(myDialog, StartDialog, EndDialog);
                    }
                }
            }
        } else {
            Vector3 drawLineStart = transform.position;
            drawLineStart.y += raycastOffset = 1.0f;
            Debug.DrawLine(raycastStart, drawLineStart + directionRaycast * sightDist, Color.green);
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

        chapter3.GetComponent<Chapter3Progress>().DetectedByScientist();
        GameObject.Find("Player").GetComponent<PlayerMovement>().Invoke("CanBeDetectedAgain", 2.0f);

    }

    public void CanDetect() {
        canDetect = true;
    }
}
