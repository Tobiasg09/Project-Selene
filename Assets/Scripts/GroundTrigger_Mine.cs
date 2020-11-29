using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger_Mine : MonoBehaviour
{
    public bool isMine = false;
    public Transform spawnPoint;

    public TextAsset C2_SurfQuest_DialogMine;
    private DialogManager dialogManager;
 

    void Start() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "PlayerFeet") {

            if (isMine) {
                dialogManager.Talk(C2_SurfQuest_DialogMine, StartDialog, EndDialogMine);
            }
        }
    }




    void MakePlayerMove() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
    }




    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
    }

    public void EndDialogMine() {
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(spawnPoint);
        Invoke("MakePlayerMove",1.0f);

    }
}
