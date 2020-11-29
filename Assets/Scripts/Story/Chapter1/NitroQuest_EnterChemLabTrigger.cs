using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroQuest_EnterChemLabTrigger : MonoBehaviour
{
    public GameObject chapter1;

    public TextAsset myDialog;


    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "MainCharacter") {
            if (chapter1.GetComponent<Chapter1Progress>().questNitrogenDoing == true) {
                chapter1.GetComponent<Chapter1Progress>().EnteredChemLab();
                
            } else {
                DialogManager dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
                dialogManager.Talk(myDialog, StartDialog, EndDialog);
            }
        } 
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
