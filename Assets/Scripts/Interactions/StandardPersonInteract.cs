using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPersonInteract : MonoBehaviour
{
    //Reference to the dialog
    public TextAsset myDialog;


    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        dialogManager.Talk(myDialog, StartDialog, EndDialog);
    }


    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        if (GameObject.Find("Player").GetComponent<Transform>().position.x < GetComponent<Transform>().position.x) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
    }
}
