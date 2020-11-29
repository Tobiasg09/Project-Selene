using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcade : MonoBehaviour
{
    //Reference to the dialog
    public TextAsset myDialog;


    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        dialogManager.Talk(myDialog, StartDialog, EndDialog);
    }


    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
    }
}
