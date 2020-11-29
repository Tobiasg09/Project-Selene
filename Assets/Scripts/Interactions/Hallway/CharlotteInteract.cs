using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharlotteInteract : MonoBehaviour
{
    //Reference to the dialog
    public TextAsset myDialog;
    public TextAsset myDialogC3;
    private int chapter;

    //C2 TriaQuest vars
    public Chapter2Progress chapter2Progress;


    public void Talk() {
        DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;


        if (chapter == 2) {
            int triaQuestProgress = chapter2Progress.C2_TriaQuest_Progress;
            int surfQuestProgress = chapter2Progress.C2_SurfQuest_Progress;
            if ( (triaQuestProgress == 3) ) {
                chapter2Progress.TalkCharlotte();
            }

            if (surfQuestProgress == -1 && triaQuestProgress == -1) {
                chapter2Progress.TalkCharlotteEpilog();
            }

        }
        if (chapter == 3) {
            dialogManager.Talk(myDialogC3, StartDialog, EndDialog);    
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
