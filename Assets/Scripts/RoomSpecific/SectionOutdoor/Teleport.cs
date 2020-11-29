using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //Reference to the dialog
    public TextAsset myDialog;

    //C2 SurfQuest vars
    public Chapter2Progress chapter2Progress;

    private DialogManager dialogManager;

    public Transform spawnStateBaseOutdoor;

    public void Start() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }

    public void Talk() {
        int surfQuestProgress = chapter2Progress.C2_SurfQuest_Progress;
        if (surfQuestProgress == 1 || surfQuestProgress == 2) {
            chapter2Progress.Teleport();
        } else {
            dialogManager.Talk(myDialog, StartDialog, EndDialog);
        }
    }



    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
    }

    public void EndDialog() {
        bool wantTeleport = (int) dialogManager.story.variablesState["wantTeleport"] == 1 ? true : false;
        if (wantTeleport) { 
            GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(spawnStateBaseOutdoor);
        }

        Invoke("CanMove",2.0f);
    }

    public void CanMove() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
    }
}
