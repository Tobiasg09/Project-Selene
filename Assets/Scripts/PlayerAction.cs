using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //If player pressed Action button - then what happens?

    public float interactRange = 5.0f;
    public Transform playerTf;

    public bool canInteract = true;

    private Interact selectedInteractee;
    private bool isActionInUse = false; //to make sure if you keep pressing it, it doesn't keep triggering


    void Update()
    {
        if (Input.GetAxis("Action") == 1) { //if you press the action (space) key 
            
            if (isActionInUse == false) {
                isActionInUse = true;                

                if (canInteract) {

                    selectedInteractee = FindInteractee();
                    if (selectedInteractee != null) {
                        selectedInteractee.Interacting();
                    }
                }
                

            }
        }

        if (Input.GetAxis("Action") == 0) {
            isActionInUse=false;
        }
    }






    Interact FindInteractee() {
        //will return itself if no suitable replacement is found

        Interact[] interactees;
        float rmin = interactRange;
        Interact interactObj = null;
        float dist2;

        interactees = FindObjectsOfType(typeof(Interact)) as Interact[]; //Is list of all the interactable objects

        foreach(Interact interactee in interactees) { //loop over all interactees
            if (interactee.interactable) { //if the interactee has the interactable bool turned on

                //calculate distances. Do it squared as it is expensive to compute square roots.
                dist2 = Mathf.Pow(interactee.gameObject.transform.position.x - playerTf.position.x, 2.0f) + Mathf.Pow(interactee.gameObject.transform.position.y - playerTf.position.y, 2.0f);

                if (dist2 < interactRange && dist2 < interactee.interactRange) { //check if within range of both interactRanges

                    if (interactObj == null) { //if it is the first object that passes all tests
                        rmin = dist2;
                        interactObj = interactee;

                    } else { //if not first object
                        if (dist2 < rmin) { //if it is closer than the previous one
                            rmin = dist2;
                            interactObj = interactee;
                        }
                    }
                }
            }
        }
        
        return interactObj;    
    }




    public void ToggleCanInteract(bool canInteractTemp, float waitTime=0.0f) { //public method that can be called to force the player to stop moving
        StartCoroutine(ToggleCanInteractHelper(canInteractTemp, waitTime));
    }

    IEnumerator ToggleCanInteractHelper(bool canInteractTemp, float waitTime) {
        yield return new WaitForSeconds(waitTime);
        if (canInteractTemp) {
            canInteract = true;
        } else {
            canInteract = false;
        }
    }







}


