using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KwameInteract : MonoBehaviour
{
    //Reference to the dialog
    public TextAsset myDialog;
    private int chapter;

    //C2 TriaQuest vars
    public Chapter2Progress chapter2Progress;


    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;


        if (chapter == 2) {
            int triaQuestProgress = chapter2Progress.C2_TriaQuest_Progress;
            if ( (triaQuestProgress == 3) ) {
                chapter2Progress.TalkKwame();
            }
        }

        dialogManager.Talk(myDialog, StartDialogNameNeeded, EndDialog);
    }


    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
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
