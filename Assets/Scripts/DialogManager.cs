using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; //for all TextMeshProp stuff
using Ink.Runtime; //for all ink-related stuff
using UnityEngine.UI; //for all button-related stuff
using System; // for the Action
using UnityEngine.EventSystems; // for some button stuff (.select())

public class DialogManager : MonoBehaviour
{

    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public GameObject choicePanel;
    public GameObject choicePrefab;
    public Animator animator;
    public GameObject continueButton;
    public GameObject ChoicePointer;

    public Story story;

    public float typingSpeed = 0.01f;

    private Action startDialogAction;
    private Action endDialogAction;

    private bool canSkip = false; //can skip text faster
    private bool isActionInUse = false; //to make sure if you keep pressing it, it doesn't keep triggering
    private bool finishedTyping = true; //false if the text is still scrolling on the screen
    private bool canTalk = true; //true if no dialogue is currently displaying
    private bool waitingForChoicePanel = false;

    //Used to select button with keyboard
    private GameObject[] currentChoiceButtons;
    private int currentChosenButton;
    private bool canMoveChoice = true;
    private bool waitingForChoice = false;

    


    public void Talk(TextAsset myDialog, Action startAction, Action endAction) {
        if (canTalk) {
            canTalk = false;
            Invoke("CanSkip",0.1f);
            
            endDialogAction = endAction;

            animator.SetBool("IsOpen",true);
            choicePanel.SetActive(false); //in first frame, no choice has to be made

            story = new Story (myDialog.text); //save myDialog in Ink Story variable
            startAction.Invoke(); 
            RefreshView();
        }
    }


    public void RefreshView() { //this is called every time dialog needs to update
        FindObjectOfType<AudioManager>().Play("Interact");
        if (story.canContinue) { //if there is a next bit, store the next text bit and display it
            DisplayDialog();

        } else {

            if (story.currentChoices.Count == 0) { //if story cannot continue and we're also not waiting for options, then the dialog is over
                animator.SetBool("IsOpen",false);
                canTalk = true;
                canSkip = false;
                dialogText.text = "";
                endDialogAction.Invoke();
            } else { //if cannot continue to next part, but there are still choices, it means you need to select a choice
                ChooseCurrentChoice();
            }
        }
    }




    void DisplayDialog() {
        //you can create the new dialog as a prefab (similar what we do with the questions) if you wanna see all dialog options. Instead, we just alter the text of the dialog panel. If interested in other option; go to Ink Trial 1
        dialogText.text = "";
        string text = story.Continue ();


        if(story.currentChoices.Count > 0) { //if there is not a next bit, maybe you have to make a choice. If there are choices, display them.
                waitingForChoicePanel = true;
        }
        StartCoroutine(Type(text));
    }


    void DisplayChoices() { //the Choice type is also from Ink
    //If displaying choices, remove previous ones
        RemoveChoices();
        if (waitingForChoicePanel) {
            waitingForChoice = true;
            //Make list of buttons gameobjects. Needed to select them with keyboard later
            currentChoiceButtons = new GameObject[story.currentChoices.Count];

            for (int i = 0; i < story.currentChoices.Count; i++) {
                choicePanel.SetActive(true);
                Choice currentChoice = story.currentChoices[i];

                GameObject choiceObject = Instantiate(choicePrefab, choicePanel.transform);
                // set the text of the Button to the text of the choice
                choiceObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentChoice.text; 

                //set that what shuold happen when button is clicked
                choiceObject.GetComponent<Button>().onClick.AddListener(delegate { ChooseChoice(currentChoice);});

                //put button in right position for it to be chosen later
                currentChoiceButtons[i] = choiceObject;
                
            }
            currentChosenButton = 0; //Standard choice is 0
            StartCoroutine(SelectButtonAFrameLater());
            //currentChoiceButtons[currentChosenButton].GetComponent<Button>().Select();
        }
        
        waitingForChoicePanel = false;

        
    }

    void RemoveChoices() {
        //Remove all choices 
        for (int i = 0; i < choicePanel.transform.childCount; i++) {
            Destroy(choicePanel.transform.GetChild(i).gameObject);
        }

    }

    //This is what happens when button is clicked!
    void ChooseChoice (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
        //Remove all choices 
        RemoveChoices();
        choicePanel.SetActive(false); //in first frame, no choice has to be made
		RefreshView();
    }



    public IEnumerator Type(string text)
    {   
        waitingForChoice = false;
        typingSpeed = 0.01f;
        finishedTyping = false;   
        continueButton.SetActive(false);

        foreach(char letter in text.ToCharArray())
        {
            if (typingSpeed == 0.0f) {
                dialogText.text += letter;
                
            } else {
                dialogText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            
        }
        

      
        finishedTyping = true;
        continueButton.SetActive(true);
        DisplayChoices();       
    }

    void CanSkip() { //so that user can skip text faster. Only activated after very short time text has started. Otherwise starting the text immediately skipped it.
        canSkip = true;
    }

    // Methods to select which choice using the keyboard

    void MoveChoiceUp() {
        canMoveChoice = false;
        StartCoroutine(ToggleEnableMoveChoice(true,0.15f));
        if (currentChosenButton < currentChoiceButtons.Length - 1) {
            currentChosenButton = currentChosenButton+1;
        }
        Debug.Log(currentChosenButton);
        StartCoroutine(SelectButtonAFrameLater());
    }

    void MoveChoiceDown() {
        canMoveChoice = false;
        StartCoroutine(ToggleEnableMoveChoice(true,0.15f));
        if (currentChosenButton > 0) {
            currentChosenButton = currentChosenButton-1;
        }
        Debug.Log(currentChosenButton);
        StartCoroutine(SelectButtonAFrameLater());
        
    }

    void ChooseCurrentChoice() {
        currentChoiceButtons[currentChosenButton].GetComponent<Button>().onClick.Invoke();
        waitingForChoice = false;
    }

    IEnumerator SelectButtonAFrameLater() {
        yield return 1;
        Debug.Log("Moving");
        currentChoiceButtons[currentChosenButton].GetComponent<Button>().Select();
        currentChoiceButtons[currentChosenButton].GetComponent<Button>().OnSelect(null);
        //Vector3 posPointer = ChoicePointer.transform.position;
        //posPointer.y = currentChoiceButtons[currentChosenButton].transform.position.y;
        //ChoicePointer.transform.position = posPointer;
    }

    IEnumerator ToggleEnableMoveChoice(bool temp, float waitTime = 0.0f) {
        yield return new WaitForSeconds(waitTime);
        if (temp) {
            canMoveChoice = true;
        } else {
            canMoveChoice = false;
        }
    }




    void Update() {
        if (Input.GetAxis("Action") == 1) { //so IF you are pressing action, and it is the action down and the dialog has finished printing, you can continue
            if (isActionInUse == false) {
                isActionInUse = true;
                if (canTalk == false) { //so if you are actually talking
                    if (finishedTyping) {     
                        RefreshView();
                        Debug.Log("Refresh");
                    } else if (canSkip) {
                        typingSpeed = 0.0f;
                        Debug.Log("Skip");
                    }
                }
            }
        }
        

        if (Input.GetAxis("Action") == 0) {
            isActionInUse=false;
            typingSpeed = 0.01f;
        }


        if (waitingForChoice) {
            float vertInput =Input.GetAxisRaw("Vertical");
            if (canMoveChoice) {
                if (vertInput > 0) {
                    MoveChoiceDown();
                }
                if (vertInput < 0) {
                    MoveChoiceUp();
                }
            }
        }
        

    }


}
