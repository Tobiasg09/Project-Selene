using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wineglass : MonoBehaviour
{


    //Reference to the dialog
    public TextAsset myDialog;

    private int drunk;

    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        dialogManager.Talk(myDialog, StartDialog, EndDialog);
    }


    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);

        //look at what was answered
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        drunk = (int) dialogManager.story.variablesState["drunk"];
        if (drunk == 1) {
            GameObject.Find("Player").GetComponent<PlayerMovement>().isDrunk = true;
        }

    }
}
