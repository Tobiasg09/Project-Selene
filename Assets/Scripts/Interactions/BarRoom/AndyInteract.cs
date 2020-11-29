using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndyInteract : MonoBehaviour
{
    private int chapter;
    private DialogManager dialogManager;
    public TextAsset myDialog;

    //C1 ElecQuest vars //
    public Chapter1Progress chapter1Progress;

    //C2 TriaQuest vars
    public Chapter2Progress chapter2Progress;

    // Start is called before the first frame update
    void Start()
    {
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }




    public void Talk() {
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;

        if (GameObject.Find("Player").GetComponent<Transform>().position.x < GetComponent<Transform>().position.x) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (chapter == 1) {
            int elecQuestProgress = chapter1Progress.elecQuestProgress;

            //if elecQuest not yet started
            if (elecQuestProgress ==  0) {
                chapter1Progress.StartedElecQuest();
            }

            if (elecQuestProgress == 1) {
                chapter1Progress.TalkAndy_S1();
            }

            if (elecQuestProgress == 2) {
                chapter1Progress.FoundIssue();
            }

            if ( (elecQuestProgress == 3) || (elecQuestProgress == 4)){
                chapter1Progress.TalkAndy_S3();
            }
        }

        if (chapter == 2) {
            int triaQuestProgress = chapter2Progress.C2_TriaQuest_Progress;
            if ( (triaQuestProgress == 2) || (triaQuestProgress == 3) ) {
                chapter2Progress.TalkAndy();
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
