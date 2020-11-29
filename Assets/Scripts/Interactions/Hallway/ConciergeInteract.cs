using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConciergeInteract : MonoBehaviour
{
    //Reference to the dialog
    public TextAsset myDialog;

    DialogManager dialogManager;


    public void Talk() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        dialogManager.Talk(myDialog, StartDialog, EndDialog);
    }


    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        if (GameObject.Find("Player").GetComponent<Transform>().position.x < GetComponent<Transform>().position.x) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //set player name in dialog
        dialogManager.story.variablesState["player_name"] = GameObject.Find("Player").GetComponent<PlayerSprite>().playerName;
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
    }
}
