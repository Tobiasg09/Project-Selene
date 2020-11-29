using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeiInteract : MonoBehaviour
{
    private int chapter;
    private DialogManager dialogManager;

    public TextAsset dialogStartQuestC1;
    public TextAsset dialogDoingQuestNitrogen;
    public TextAsset myDialog;
    

    public GameObject BioLabNitrogen;


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
            if (GameObject.Find("Chapter1").GetComponent<Chapter1Progress>().questNitrogenStarted == false) {
                dialogManager.Talk(dialogStartQuestC1, StartDialog, EndDialog);
                GameObject.Find("Chapter1").GetComponent<Chapter1Progress>().questNitrogenStarted = true;
                GameObject.Find("Chapter1").GetComponent<Chapter1Progress>().questNitrogenDoing = true;

                BioLabNitrogen.SetActive(false);
            }

            if (GameObject.Find("Chapter1").GetComponent<Chapter1Progress>().questNitrogenDoing == true) {
                dialogManager.Talk(dialogDoingQuestNitrogen, StartDialog, EndDialog);
            }
        }

        if (chapter == 2) {
            int triaQuestProgress = chapter2Progress.C2_TriaQuest_Progress;
            if ( (triaQuestProgress == 3) ) {
                chapter2Progress.TalkMei();
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
