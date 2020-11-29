using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
     //Reference to the dialog
    public TextAsset myDialog;
    private int chapter;

    //C2 TriaQuest vars
    public Chapter3Progress chapter3Progress;


    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;


        if (chapter == 3) {
            int codeQuestProgress = chapter3Progress.C3_CodeQuest_Progress;
            if ( (codeQuestProgress == 1) ) {
                chapter3Progress.TalkDoor();
            }
        }

        dialogManager.Talk(myDialog, StartDialog, EndDialog);
    }


    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
    }
}
