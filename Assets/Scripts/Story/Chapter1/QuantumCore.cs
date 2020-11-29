using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumCore : MonoBehaviour
{
    private int chapter;
    private DialogManager dialogManager;
    public TextAsset myDialog;

    public Sprite coreNotFound;
    public Sprite coreFound;

    public bool foundCore = false;

    //C1 ElecQuest vars //
    public Chapter1Progress chapter1Progress;


    // Start is called before the first frame update
    void Start()
    {
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }




    public void Talk() {

        if (chapter == 1) {
            int elecQuestProgress = chapter1Progress.elecQuestProgress;

            if  ( (elecQuestProgress < 3) && (elecQuestProgress >= 0) ) { //ie not looking for core yet
                dialogManager.Talk(myDialog, StartDialog, EndDialog);
            }
            

            //if searching for Quantum Core
            if (elecQuestProgress ==  3) {
                chapter1Progress.FoundQuantumCore();
            }
        }


        
    }

    public void Update() {
        if (foundCore) {
            GetComponent<SpriteRenderer>().sprite = coreFound;
        } else {
            GetComponent<SpriteRenderer>().sprite = coreNotFound;
        }
    }




    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
    }
    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
    }
}
