using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomInteract : MonoBehaviour
{

    private int chapter;
    private DialogManager dialogManager;

    public TextAsset dialogDoingQuestNitrogen;
    public TextAsset dialogHasNitrogen;
    public TextAsset myDialog;

    public GameObject BioLabNitrogen;

    // Start is called before the first frame update
    void Start()
    {
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }

    public void Talk() {

        if (chapter == 1) {

            if ((GameObject.Find("Chapter1").GetComponent<Chapter1Progress>().hasNitrogen == true) && (GameObject.Find("Chapter1").GetComponent<Chapter1Progress>().questNitrogenDoing == true)) {
                dialogManager.Talk(dialogHasNitrogen, StartDialog, EndDialogFinishedQuestNitrogen);
                GameObject.Find("Chapter1").GetComponent<Chapter1Progress>().questNitrogenFinished = true;
                GameObject.Find("Chapter1").GetComponent<Chapter1Progress>().questNitrogenDoing = false;
            }

            if (GameObject.Find("Chapter1").GetComponent<Chapter1Progress>().questNitrogenDoing == true) {
                dialogManager.Talk(dialogDoingQuestNitrogen, StartDialog, EndDialog);
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


    public void EndDialogFinishedQuestNitrogen() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        BioLabNitrogen.SetActive(true);
    }
}
