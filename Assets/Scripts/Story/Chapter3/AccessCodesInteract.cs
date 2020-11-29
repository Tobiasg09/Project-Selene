using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessCodesInteract : MonoBehaviour
{

    private int chapter;

    //C2 TriaQuest vars
    public Chapter3Progress chapter3Progress;


    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;


        if (chapter == 3) {
            int codeQuestProgress = chapter3Progress.C3_CodeQuest_Progress;
            if ( (codeQuestProgress == 1) ) {
                chapter3Progress.FoundCodes();
            }
        }
    }
}
