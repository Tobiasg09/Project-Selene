using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemLabNitrogen : MonoBehaviour
{
    //Reference to the dialog
    public TextAsset myDialog;
    public bool tookNitrogen = false;
    public GameObject chapter1;

    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        dialogManager.Talk(myDialog, StartDialog, EndDialog);
    }

    
    
    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        Debug.Log("Test");
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);

        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        tookNitrogen = (int) dialogManager.story.variablesState["tookNitrogen"] == 1 ? true : false;

        
        if (tookNitrogen == true) {
            chapter1.GetComponent<Chapter1Progress>().TookNitrogen();
        }
    }
}
