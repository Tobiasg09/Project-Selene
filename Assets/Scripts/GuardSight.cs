using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSight : MonoBehaviour
{

    public float sightDist;
    //Reference to the dialog
    public TextAsset myDialog;

    private Vector3 prevPos = Vector2.zero;

    void Start() {
        Physics2D.queriesStartInColliders = false; //to make sure it doesn't detect itself with the raycast
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 direction = GameObject.Find("Utils").GetComponent<Utilities>().FromWhichDirection(prevPos, transform.position);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,  direction, sightDist);  //where the ray should start, which direction it should have and the max distance 
        if (hitInfo.collider != null) {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red); //hitInfo.point is position of collision of raycast

            if (hitInfo.collider.CompareTag("MainCharacter")) {
                Debug.Log("Aw hit");
                DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
                dialogManager.Talk(myDialog, StartDialog, EndDialog);
            }
        } else {
            Debug.DrawLine(transform.position, transform.position + direction * sightDist, Color.green);
        }




        prevPos = transform.position;
    }



    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GetComponent<Patroller>().TogglePausePatrol(true);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GetComponent<Patroller>().TogglePausePatrol(false);
    }
}
