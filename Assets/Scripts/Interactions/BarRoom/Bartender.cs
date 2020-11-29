using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bartender : MonoBehaviour
{
    private int chapter;

    //Reference to the dialog
    public TextAsset myDialog;


    //C2 TriaQuest vars//
    public Chapter2Progress chapter2Progress;


    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();


         if (GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter == 2) {
             int triaQuestProgress = chapter2Progress.C2_TriaQuest_Progress;
             if (triaQuestProgress == 1) {
                 chapter2Progress.TalkBartender();
             }
         }

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
