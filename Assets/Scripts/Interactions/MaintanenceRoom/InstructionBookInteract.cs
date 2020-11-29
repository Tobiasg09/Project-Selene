using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionBookInteract : MonoBehaviour
{
    private int chapter;
    private DialogManager dialogManager;
    public TextAsset myDialog;


    //C3 MessQuest vars//
    public Chapter3Progress chapter3Progress;


    void Start()
    {
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }


    public void Talk() {

        if (chapter == 3) {
            int messQuestProgress = chapter3Progress.C3_MessQuest_Progress;
            //if messQuest has started but not yet in final stage
        
            if (messQuestProgress == 1) {
                chapter3Progress.IntructionBook();
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
