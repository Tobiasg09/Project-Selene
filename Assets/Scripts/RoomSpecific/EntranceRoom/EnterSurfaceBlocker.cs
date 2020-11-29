using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSurfaceBlocker : MonoBehaviour
{

    private int chapter;
    public TextAsset myDialog;
    private DialogManager dialogManager;

    //C2 SurfQuest vars
    public Chapter2Progress chapter2Progress;

    void Start() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }

    
    void OnCollisionEnter2D(Collision2D other){
        Debug.Log(other);
        if (other.gameObject.name == "Player") {
            chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;
            int surfQuestProgress = chapter2Progress.C2_SurfQuest_Progress;

            if (chapter > 2 || surfQuestProgress > 0) {
                Destroy(gameObject);
            } else {
                dialogManager.Talk(myDialog, StartDialog, EndDialog);
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
