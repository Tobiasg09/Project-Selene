using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiotrInteract : MonoBehaviour
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
                chapter2Progress.TalkPiotr();
            }

        }

        dialogManager.Talk(myDialog, StartDialog, EndDialog);

        if (GameObject.Find("Player").GetComponent<Transform>().position.x < GetComponent<Transform>().position.x) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }


    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
    }
}
