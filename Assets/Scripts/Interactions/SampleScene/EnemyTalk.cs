using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTalk : MonoBehaviour
{

    //Reference to the dialog
    public TextAsset myDialog;

    private DialogManager dialogManager;



    public void Talk() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        dialogManager.Talk(myDialog, StartDialog, EndDialog); //put in dialog
        //GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false); //make player unable to move


    }

    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GetComponent<Patroller>().TogglePausePatrol(true);
        //turn to player. Can later use the utils function if we have images for all four directions
        if (GameObject.Find("Player").GetComponent<Transform>().position.x < GetComponent<Transform>().position.x) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GetComponent<Patroller>().TogglePausePatrol(false);
    }

 
}
