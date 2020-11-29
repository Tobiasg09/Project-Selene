using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events; //for the UnityEvent

public class Interact : MonoBehaviour
{
    //Allows this gameobject to be interacted with
    public bool interactable = true;
    public float interactRange = 5.0f; //however, if this is larger than the interactrange of the player, nothing will happen
    public UnityEvent interaction;
    
    
    public void Interacting() { //interactor is usually the player
        interaction.Invoke();
    }
}
