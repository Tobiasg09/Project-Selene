using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInteract : MonoBehaviour
{
    //Reference to the dialog
    public TextAsset myDialog;


    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        dialogManager.Talk(myDialog, StartDialogNameNeeded, EndDialog);
    }


    public void StartDialogNameNeeded() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        dialogManager.story.variablesState["player_name"] = GameObject.Find("Player").GetComponent<PlayerSprite>().playerName;

        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
    }
}
