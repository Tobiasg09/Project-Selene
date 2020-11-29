using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlyssaInteract : MonoBehaviour
{
    private int chapter;

    //C2 TriaQuest vars
    public Chapter2Progress chapter2Progress;


    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;


        if (chapter == 2) {
            int surfQuestProgress = chapter2Progress.C2_SurfQuest_Progress;

            if (surfQuestProgress == 2 || surfQuestProgress == 3) {
                chapter2Progress.TalkAlyssa();
            }
        }
    }


    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
    }
}
