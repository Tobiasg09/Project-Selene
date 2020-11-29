using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour
{
    private int chapter;
    private DialogManager dialogManager;
    public TextAsset myDialog;


    //C1 ElecQuest vars //
    public Chapter1Progress chapter1Progress;

    //C3 MessQuest vars//
    public Chapter3Progress chapter3Progress;


    // Start is called before the first frame update
    void Start()
    {
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }




    public void Talk() {

        if (chapter == 1) {
            int elecQuestProgress = chapter1Progress.elecQuestProgress;

            //if elecQuest not yet started
            if (elecQuestProgress ==  1 || elecQuestProgress ==  2) {
                chapter1Progress.FoundComputer();
            }

            if (elecQuestProgress == 4) { //ie quantumcore found
                chapter1Progress.QuantumCoreInstalled();
            }
        }

        if (chapter == 3) {
            int messQuestProgress = chapter3Progress.C3_MessQuest_Progress;
            //if messQuest has started but not yet in final stage
            if (messQuestProgress == 1) {
                chapter3Progress.DecodingMorse();
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
