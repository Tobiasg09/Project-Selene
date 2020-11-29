using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public RuntimeAnimatorController animatorF;
    public RuntimeAnimatorController animatorM;

    public bool playerFemale = true;

    public string playerName = "Meredith";


    void Update()
    {
        Animator animator = GetComponent<Animator>();

        if (playerFemale) {
            animator.runtimeAnimatorController = animatorF as RuntimeAnimatorController;
            playerName = "Meredith";
        } else {
            animator.runtimeAnimatorController = animatorM as RuntimeAnimatorController;
            playerName = "Marvin";
        }
    }

    
}
