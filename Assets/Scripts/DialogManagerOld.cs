using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; //for TMPro things
using System; // for the Action


//Based loosely on https://www.youtube.com/watch?v=f-oSXg6_AMQ

//maybe this would be better/faster: https://www.youtube.com/watch?v=_nRzoTzeyxU&t=45s


//Maybe use this font https://opengameart.org/content/bitscript-true-type-font

public class DialogManagerOld : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public Animator animator;

    private bool canContinue = false; //false if the text is still scrolling on the screen
    private bool pressedContinue = false; //true if you pressed continue
    private bool canTalk = true; //true if no dialogue is currently displaying
    public float typingSpeedDefault = 0.02f;

    private bool isActionInUse = false; //to make sure if you keep pressing it, it doesn't keep triggering


    public GameObject continueButton;





    void Update() {

    
        if (Input.GetAxis("Action") == 1) {
            if (isActionInUse == false) {
                isActionInUse = true;
                if (canContinue) {
                    
                    NextSentence();
                }
            }
        }

        if (Input.GetAxis("Action") == 0) {
            isActionInUse=false;
        }
       


        
    }

 
    public void Talk(Dialog dialog, Action startAction, Action endAction, float typingSpeed = 0.02f) { //endAction is a function that is to be called after dialog ends
        if (canTalk) {
            canTalk = false;
            startAction.Invoke();


            continueButton.SetActive(false);
            canContinue = false;
            animator.SetBool("IsOpen",true);

            StartCoroutine(Type(dialog, typingSpeed, endAction));



        } 
        
    }

    public IEnumerator Type(Dialog dialog, float typingSpeed, Action endAction)
    {
        foreach(string sentence in dialog.sentences) {
            
            foreach(char letter in sentence.ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            continueButton.SetActive(true); //if finished with typing, can display the continue button
            canContinue = true;

            while (pressedContinue == false) {
                yield return null;
            }

            continueButton.SetActive(false);
            canContinue = false;
            pressedContinue = false;
            textDisplay.text = "";

        }

        animator.SetBool("IsOpen",false);
        endAction.Invoke();
        Invoke("Delay", 0.2f);

        
        
    }

    public void NextSentence() {
        pressedContinue = true;
    }

    public void Delay() {
        canTalk = true;
    }
}
