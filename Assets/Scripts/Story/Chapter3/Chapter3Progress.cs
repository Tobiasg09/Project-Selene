using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //for image manipulation
using TMPro; //for all TextMeshProp stuff
using UnityEngine.SceneManagement; //for scene manipulation

public class Chapter3Progress : MonoBehaviour
{

    private DialogManager dialogManager;
    private StoryProgress storyProgress;
    private int chapter;

    public GameObject hallPeople;
    public GameObject barPeople;
    public GameObject blackScreen;
    public bool isActionInUse;


    //ChapterScreen variables//
    public GameObject chapterScreen;
    public TextMeshProUGUI chapterText;
    public TextMeshProUGUI chapterQuoteText;


    // START CHAPTER VARIABLES 
    public Transform C3_Intro_Spawn;
    public GameObject C3_Intro_HallPeople;
    public TextAsset C3_Intro_Dialog;


    //ACCESS CODE QUEST VARIABLES;
    public int C3_CodeQuest_Progress = 0;
    public TextAsset C3_CodeQuest_DialogTriggerDoor;
    public GameObject C3_CodeQuest_Door;
    public TextAsset C3_CodeQuest_DialogDoor;
    public TextAsset C3_CodeQuest_DialogPreSneak;
    public Transform C3_CodeQuest_respawnPositionState;
    public TextAsset C3_CodeQuest_DialogPreAntiGrav;
    public TextAsset C3_CodeQuest_DialogCommsFac;
    public GameObject C3_CodQuest_Codes;
    public TextAsset C3_CodeQuest_DialogFoundCodes;
    

    // MESSAGE QUEST VARIABLES
    public int C3_MessQuest_Progress = 0;
    public GameObject C3_MessQuest_Scientist;
    public TextAsset C3_MessQuest_DialogStartQuest;
    public TextAsset C3_MessQuest_DialogMoreInfo;
    public TextAsset C3_MessQuest_DialogComputerDoing;
    public TextAsset C3_MessQuest_DialogMorseGuide;
    public TextAsset C3_MessQuest_DialogFinal;
    private bool C3_MessQuest_SuccesDecode;


    // EPILOG VARIABLES //
    public Transform C3_Epilog_Spawn;
    public GameObject C3_Epilog_BarPeople;
    public TextAsset C3_Epilog_Dialog0;
    public TextAsset C3_Epilog_DialogDivert;
    public TextAsset C3_Epilog_DialogNotDivert;
    public bool hasDiverted0 = false;
    public bool hasDiverted1 = false;
    public Transform C3_Epilog_OtherSectionSpawn;


    public GameObject endingPanel;
    public TextMeshProUGUI endText1;
    public TextMeshProUGUI endText2;
    public TextMeshProUGUI endText3;
    public TextMeshProUGUI endCont;
    public TextMeshProUGUI chapterCont;
    public int canEnd = 0; //0 if ending not yet played. 1 if ending finished playing. 2 if cont'd. 3 if you can return to menu.




    void Awake() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        storyProgress = GameObject.Find("StoryManager").GetComponent<StoryProgress>();
    }

    public void StartChapter() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        storyProgress = GameObject.Find("StoryManager").GetComponent<StoryProgress>();

        //Activate all Chapter3's in every room
        GameObject[] Chapter3GOs = storyProgress.Chapter3GOs;
        foreach (GameObject Chapter3GO in Chapter3GOs) {
            Chapter3GO.SetActive(true); 
        }


        // Disable all GO's that need to appear during quests
        C3_Epilog_BarPeople.SetActive(false);


        //Enable all GO's that need to appear during this chapter






        // Start Chapter3 intro
        FindObjectOfType<AudioManager>().ToggleCanPlayBackgroundMusic(false);
        blackScreen.SetActive(true);
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(C3_Intro_Spawn, false);
        blackScreen.GetComponent<Image>().color = new Color32(0,0,0,255); //set it to black 

    

        chapterScreen.SetActive(true);
        chapterText.text = "Chapter 3";
        chapterQuoteText.text = "Life is a sum of all your choices. \n       ~ Albert Camus";
        StartCoroutine(FadeTextInAndOut(chapterText));
        StartCoroutine(FadeTextInAndOut(chapterQuoteText));
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
    }



    public IEnumerator FadeTextInAndOut(TextMeshProUGUI text, float fadeVel = 0.1f, float midWaitTime = 1.0f ) {
        text.color = new Color32(255,255,255,0);
        int alpha=0;
        while (alpha < 255) {
            text.color = new Color32(255,255,255,(byte)alpha);
            yield return new WaitForSeconds(fadeVel);
            
            alpha += 10;
        }
        yield return new WaitForSeconds(midWaitTime);
        
        alpha = 255;
        while (alpha > 0) {
            text.color = new Color32(255,255,255,(byte)alpha);
            yield return new WaitForSeconds(fadeVel);    
            alpha -= 10;
        }

        //if finish, start the rest.
        StartChapterReal();
        chapterScreen.SetActive(false);
    }



    void StartChapterReal() {
        FindObjectOfType<AudioManager>().ToggleCanPlayBackgroundMusic(true);
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Crisis",true);
        ToggleAllHallPeople(false);
        C3_Intro_HallPeople.SetActive(true);
        StartCoroutine(FadeIn());
        Invoke("StartIntro",0.5f);
    }

    public IEnumerator FadeIn() {
        int alpha=255;
        float fadeSpeed = 0.1f;
        Image image = blackScreen.GetComponent<Image>();
        while (alpha != 0) {
            alpha -= 5;
            image.color = new Color32(0,0,0,(byte)alpha);
            yield return new WaitForSeconds(fadeSpeed);
        }
        blackScreen.SetActive(false);
    }

    public void StartIntro() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(-transform.right);
        dialogManager.Talk(C3_Intro_Dialog, StartDialogTwoNamesNeeded, EndDialogIntro);
    }


    public void EndDialogIntro() {
        GameObject.Find("StoryManager").GetComponent<StoryProgress>().hasEvacuated = (int) dialogManager.story.variablesState["hasEvacuated"] == 1 ? true : false;
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,5,1);
        Invoke("EndDialogIntroHelper",1.0f);
    }

    void EndDialogIntroHelper() {
        ToggleAllHallPeople(true);
        Destroy(C3_Intro_HallPeople);
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true, 1.0f);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true, 1.0f);
        FindObjectOfType<AudioManager>().StopOverwriteMusic();
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Main");
    }






    // Access code quest


    public void TriggerDoor() {
        dialogManager.Talk(C3_CodeQuest_DialogTriggerDoor, StartDialog, EndDialog);
        C3_CodeQuest_Progress = 1;
    }

    public void TalkDoor() {
        dialogManager.Talk(C3_CodeQuest_DialogDoor, StartDialog, EndDialogTalkDoor);
    }

    public void EndDialogTalkDoor() {
        Destroy(C3_CodeQuest_Door);
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
    }
    
    public void PreSneak() {
        dialogManager.Talk(C3_CodeQuest_DialogPreSneak, StartDialog, EndDialog);
    }

    public void DetectedByScientist() {
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(C3_CodeQuest_respawnPositionState);
    }


    public void PreAntiGrav() {
        dialogManager.Talk(C3_CodeQuest_DialogPreAntiGrav, StartDialog, EndDialog);
    }

    public void CommsFac() {
        dialogManager.Talk(C3_CodeQuest_DialogCommsFac, StartDialog, EndDialog);
    }

    public void FoundCodes() {
        dialogManager.Talk(C3_CodeQuest_DialogFoundCodes, StartDialog, EndDialogFoundCodes);
        C3_CodeQuest_Progress = -1;
    }

    public void EndDialogFoundCodes() {
        Destroy(C3_CodQuest_Codes);
        Invoke("StartEpilog",1.0f);
    }




    /* #region Message Quest */


    public void StartMessageQuest() {
        C3_MessQuest_Progress = 1;
        dialogManager.Talk(C3_MessQuest_DialogStartQuest, StartDialog, EndDialog);
    }

    public void AskScientistForMoreInformation() {
        dialogManager.Talk(C3_MessQuest_DialogMoreInfo, StartDialog, EndDialog);
    }

    public void IntructionBook() {
        dialogManager.Talk(C3_MessQuest_DialogMorseGuide, StartDialog, EndDialog);
    }


    public void DecodingMorse() {
        dialogManager.Talk(C3_MessQuest_DialogComputerDoing, StartDialog, EndDialogDecodingMorse);
    }

    public void EndDialogDecodingMorse() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
        bool C3_MessQuest_SuccesDecode = (int) dialogManager.story.variablesState["completed"] == 1 ? true : false;
        //if succesful, increase progress score
        if (C3_MessQuest_SuccesDecode) {
            C3_MessQuest_Progress = -1; 
        }
    }

    public void EndQuest() {
        dialogManager.Talk(C3_MessQuest_DialogFinal, StartDialog, EndDialog);
    }





    /* #endregion */










    // EPILOGUE

    public void StartEpilog() {
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,10,10,1);
        ToggleAllBarPeople(false);
        C3_Epilog_BarPeople.SetActive(true);
        Invoke("StartEpilogHelper",1.0f);
    }

    public void StartEpilogHelper() {
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(C3_Epilog_Spawn, false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.right);
        dialogManager.Talk(C3_Epilog_Dialog0, StartDialogTwoNamesEvacuated, EndDialogEpilog0);
    }

    public void StartDialogTwoNamesEvacuated() {
        dialogManager.story.variablesState["player_name"] = GameObject.Find("Player").GetComponent<PlayerSprite>().playerName;
        dialogManager.story.variablesState["victimName"] = GameObject.Find("StoryManager").GetComponent<StoryProgress>().trialVictimName;
        dialogManager.story.variablesState["hasEvacuated"] = GameObject.Find("StoryManager").GetComponent<StoryProgress>().hasEvacuated;

        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.right);
    }


    public void EndDialogEpilog0() {
        hasDiverted0 = (int) dialogManager.story.variablesState["hasDiverted0"] == 1 ? true : false;
        if (hasDiverted0) { //stay in bar and do second part
            Invoke("Epilog_DivertHelper",0.0f);
        } else { //move to other section and do second part there
            GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,10,1);
            Invoke("Epilog_NotDivertHelper",1.0f);
        }
    }

    public void Epilog_DivertHelper() {
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Crisis",true);
        dialogManager.Talk(C3_Epilog_DialogDivert, StartDialog, EndDialogEpilog1);
    }

    public void Epilog_NotDivertHelper() {
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Crisis",true);
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(C3_Epilog_OtherSectionSpawn, false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.up,0.1f);
        dialogManager.Talk(C3_Epilog_DialogNotDivert, StartDialogNameNeededEvacuated, EndDialogEpilog1);
    }

    public void StartDialogNameNeededEvacuated() {
        dialogManager.story.variablesState["player_name"] = GameObject.Find("Player").GetComponent<PlayerSprite>().playerName;
        dialogManager.story.variablesState["hasEvacuated"] = GameObject.Find("StoryManager").GetComponent<StoryProgress>().hasEvacuated;

        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
    }

    public void EndDialogEpilog1() {
        hasDiverted1 = (int) dialogManager.story.variablesState["hasDiverted1"] == 1 ? true : false;
        StartCoroutine(FadeOut());
        Invoke("Ending",5.0f);
    }


    public IEnumerator FadeOut() {
        blackScreen.SetActive(true);
        int alpha=0;
        float fadeSpeed = 0.01f;
        Image image = blackScreen.GetComponent<Image>();
        image.color = new Color32(0,0,0,0);
        while (alpha != 255) {
            alpha += 1;
            image.color = new Color32(0,0,0,(byte)alpha);
            yield return new WaitForSeconds(fadeSpeed);
        }
        //blackScreen.SetActive(false);
    }

    public void Ending() {

    FindObjectOfType<AudioManager>().StopOverwriteMusic();
    FindObjectOfType<AudioManager>().PlayBackgroundMusic("Sad",true);


    bool hasEvacuated = GameObject.Find("StoryManager").GetComponent<StoryProgress>().hasEvacuated;
    bool hasMessage = false;
    if (C3_MessQuest_Progress == -1) {
        hasMessage = true;
    }


    string text1 = "";
    string text2 = "";
    string text3 = "";


        // Do Ending text //

        //If divert0 = true, divert1 = true, evacuated = true, message = true
        if (hasDiverted0 && hasDiverted1 && hasEvacuated  && hasMessage) {
            text1 = "You have diverted the missile and it landed on the State base.";
            
            text2 = "Half of Project Selene section 59 was obliterated as well, killing a total of 853 people. This includes 51 refugees from your section.";
            
            text3 = "However, the world was notified of Drump's actions and rose up to him, eventually restoring democracy to the State.";
        }
        
        //If divert0 = true, divert1 = true, evacuated = true, message = false
        if (hasDiverted0 && hasDiverted1 && hasEvacuated  && hasMessage == false) {
            text1 = "You have diverted the missile and it landed on the State base.";
            
            text2 = "Half of Project Selene section 59 was obliterated as well, killing a total of 853 people. This includes 51 refugees from your section.";
            
            text3 = "Drump claimed that the missile was fired by you and that this was a terrorist attack. You cannot deny any charges and the world's remaining governments turn their back on Project Selene.";
        }

        //If divert0 = true, divert1 = true, evacuated = false, message = true
        if (hasDiverted0 && hasDiverted1 && hasEvacuated == false  && hasMessage) {
            text1 = "You have diverted the missile and it landed on the State base.";

            text2 = "A total of 632 State soldiers were killed instantly.";
            
            text3 = "However, the world was notified of Drump's actions and rose up to him, eventually restoring democracy to the State.";
        }

        //If divert0 = true, divert1 = true, evacuated = false, message = false
        if (hasDiverted0 && hasDiverted1 && hasEvacuated == false && hasMessage == false) {
            text1 = "You have diverted the missile and it landed on the State base";

            text2 = "A total of 632 State soldiers were killed instantly.";
            
            text3 = "Drump claimed that the missile was fired by you and that this was a terrorist attack. You cannot deny any charges and the world's remaining governments turn their back on Project Selene.";
        }




        //If divert0 = true, divert1 = false, evacuated = true, message = true
        if (hasDiverted0 && hasDiverted1 == false && hasEvacuated  && hasMessage) {
            text1 = "You have decided not to divert the missile and it landed on top of section 42.";
            
            text2 = "All buildings were obliterated upon impact and the last people inside were killed immediately, including you.";
            
            text3 = "However, the world was notified of Drump's actions and rose up to him, eventually restoring democracy to the State.";
        }

        //If divert0 = true, divert1 = false, evacuated = true, message = false
        if (hasDiverted0 && hasDiverted1 == false && hasEvacuated  && hasMessage == false) {
            text1 = "You have decided not to divert the missile and it landed on top of section 42.";
            
            text2 = "All buildings were obliterated upon impact and the last people inside were killed immediately, including you.";
            
            text3 = "Drump claimed that the missile was fired by you and that this was a terrorist attack. You cannot deny any charges and the world's remaining governments turn their back on Project Selene.";
        }

        //If divert0 = true, divert1 = false, evacuated = false, message = true
        if (hasDiverted0 && hasDiverted1 == false && hasEvacuated == false && hasMessage) {
            text1 = "You have decided not to divert the missile and it landed on top of section 42.";
            
            text2 = "All buildings were obliterated upon impact and everyone inside was killed immediately, including you and everyone you knew. The total death count is 189.";
            
            text3 = "However, the world was notified of Drump's actions and rose up to him, eventually restoring democracy to the State.";
        }

        //If divert0 = true, divert1 = false, evacuated = false, message = false
        if (hasDiverted0 && hasDiverted1 == false && hasEvacuated == false && hasMessage == false) {
            text1 = "You have decided not to divert the missile and it landed on top of section 42.";
            
            text2 = "All buildings were obliterated upon impact and everyone inside was killed immediately, including you and everyone you knew. The total death count is 189.";
            
            text3 =  "Drump claimed that the missile was fired by you and that this was a terrorist attack. You cannot deny any charges and the world's remaining governments turn their back on Project Selene.";
        }




        //If divert0 = false, divert1 = true, evacuated = true, message = true
        if (hasDiverted0 == false && hasDiverted1 && hasEvacuated  && hasMessage) {
            text1 = "You have diverted the missile and it landed on the State base.";
            
            text2 = "Half of Project Selene section 59 was obliterated as well, killing a total of 853 people. This includes 51 refugees from your section.";
            
            text3 = "However, the world was notified of Drump's actions and rose up to him, eventually restoring democracy to the State.";
        }

        //If divert0 = false, divert1 = true, evacuated = true, message = false
        if (hasDiverted0 == false && hasDiverted1 && hasEvacuated  && hasMessage == false) {
            text1 = "You have diverted the missile and it landed on the State base.";
            
            text2 = "Half of Project Selene section 59 was obliterated as well, killing a total of 853 people. This includes 51 refugees from your section.";
            
            text3 = "Drump claimed that the missile was fired by you and that this was a terrorist attack. You cannot deny any charges and the world's remaining governments turn their back on Project Selene.";
        }

        //If divert0 = false, divert1 = true, evacuated = false, message = true
        if (hasDiverted0 == false && hasDiverted1 && hasEvacuated == false && hasMessage) {
            text1 = "You have diverted the missile and it landed on the State base.";

            text2 = "A total of 632 State soldiers were killed instantly, although you find solace in the fact that you have saved your own people.";
            
            text3 = "The world was notified of Drump's actions and rose up to him, eventually restoring democracy to the State.";
        }

        //If divert0 = false, divert1 = true, evacuated = false, message = false
        if (hasDiverted0 == false && hasDiverted1 && hasEvacuated == false && hasMessage == false) {
            text1 = "You have diverted the missile and it landed on the State base.";

            text2 = "A total of 632 State soldiers were killed instantly, although you find solace in the fact that you have saved your own people.";
            
            text3 = "However, Drump claimed that the missile was fired by you and that this was a terrorist attack. You cannot deny any charges and the world's remaining governments turn their back on Project Selene.";
        }
        



        //If divert0 = false, divert1 = false, evacuated = true, message = true
        if (hasDiverted0 == false && hasDiverted1 == false && hasEvacuated  && hasMessage) {
            text1 = "You have decided not to divert the missile and it landed on top of section 42.";
            
            text2 = "All buildings were obliterated upon impact. However, all your people are safe now, residing in other sections across the Moon.";
            
            text3 = "Additionally, the world was notified of Drump's actions and rose up to him, eventually restoring democracy to the State.";
        }

        //If divert0 = false, divert1 = false, evacuated = true, message = false
        if (hasDiverted0 == false && hasDiverted1 == false && hasEvacuated  && hasMessage == false) {
            text1 = "You have decided not to divert the missile and it landed on top of section 42."; 
            
            text2 = "All buildings were obliterated upon impact. However, all your people are safe now, residing in other sections across the Moon.";
            
            text3 = "Drump claimed that the missile was fired by you and that this was a terrorist attack. You cannot deny any charges and the world's remaining governments turn their back on Project Selene.";
        }

        //If divert0 = false, divert1 = false, evacuated = false, message = true
        if (hasDiverted0 == false && hasDiverted1 == false && hasEvacuated  == false && hasMessage) {
            text1 = "You have decided not to divert the missile and it landed on top of section 42.";
            
            text2 = "All buildings were obliterated upon impact and the last remaining people inside were killed immediately. The total death count is 54.";
            
            text3 = "However, the world was notified of Drump's actions and rose up to him, eventually restoring democracy to the State.";
        }

        //If divert0 = false, divert1 = false, evacuated = false, message = false
        if (hasDiverted0 == false && hasDiverted1 == false && hasEvacuated  == false && hasMessage == false) {
            text1 = "You have decided not to divert the missile and it landed on top of section 42.";
            
            text2 = "All buildings were obliterated upon impact and the last remaining people inside were killed immediately. The total death count is 54.";
            
            text3 = "Drump claimed that the missile was fired by you and that this was a terrorist attack. You cannot deny any charges and the world's remaining governments turn their back on Project Selene.";
        }

        endingPanel.SetActive(true);
        endText1.text = text1;
        endText2.text = text2;
        endText3.text = text3;

        StartCoroutine(FadeTextIn(endText1, 0.1f, 0.0f));
        StartCoroutine(FadeTextIn(endText2, 0.1f, 2.0f));
        StartCoroutine(FadeTextIn(endText3, 0.1f, 4.0f));
        StartCoroutine(FadeTextIn(endCont, 0.1f, 6.0f));
        Invoke("CanEnd",9.0f);






    }


    public IEnumerator FadeTextIn(TextMeshProUGUI text, float fadeVel = 0.1f, float waitTime = 0.0f) {
        text.color = new Color32(255,255,255,0);
        yield return new WaitForSeconds(waitTime);
        int alpha=0;
        while (alpha < 255) {
            text.color = new Color32(255,255,255,(byte)alpha);
            yield return new WaitForSeconds(fadeVel);
            alpha += 10;
        }
    }

    void CanEnd() {
        canEnd = 1;
    }

    void PlayFin() {
        
        StartCoroutine(FadeTextOut(endText1, 0.1f, 0.0f));
        StartCoroutine(FadeTextOut(endText2, 0.1f, 0.0f));
        StartCoroutine(FadeTextOut(endText3, 0.1f, 0.0f));
        StartCoroutine(FadeTextOut(endCont, 0.1f, 0.0f));
        Invoke("PlayFinHelper",2.0f);
    }


    public IEnumerator FadeTextOut(TextMeshProUGUI text, float fadeVel = 0.1f, float waitTime = 0.0f) {
        text.color = new Color32(255,255,255,0);
        yield return new WaitForSeconds(waitTime);
        int alpha=255;
        while (alpha > 0) {
            text.color = new Color32(255,255,255,(byte)alpha);
            yield return new WaitForSeconds(fadeVel);
            alpha -= 20;
        }
    }

    void PlayFinHelper() {
        chapterScreen.SetActive(true);
        endingPanel.SetActive(false); //maybe fade out instead?
        chapterText.text = "FIN";
        chapterQuoteText.text = "Life is a sum of all your choices. \n       ~ Albert Camus";
        StartCoroutine(FadeTextInEnding(chapterText,0.1f));
        StartCoroutine(FadeTextInAndOutEnding(chapterQuoteText));
        Invoke("PlayFinFin", 7.0f);
    }


    public IEnumerator FadeTextInEnding(TextMeshProUGUI text, float fadeVel = 0.1f) {
        text.color = new Color32(255,255,255,0);
        int alpha=0;
        while (alpha < 255) {
            text.color = new Color32(255,255,255,(byte)alpha);
            yield return new WaitForSeconds(fadeVel);
            
            alpha += 10;
        }

    }



    public IEnumerator FadeTextInAndOutEnding(TextMeshProUGUI text, float fadeVel = 0.1f, float midWaitTime = 1.0f ) {
        text.color = new Color32(255,255,255,0);
        int alpha=0;
        while (alpha < 255) {
            text.color = new Color32(255,255,255,(byte)alpha);
            yield return new WaitForSeconds(fadeVel);
            
            alpha += 10;
        }
        yield return new WaitForSeconds(midWaitTime);
        
        alpha = 255;
        while (alpha > 0) {
            text.color = new Color32(255,255,255,(byte)alpha);
            yield return new WaitForSeconds(fadeVel);    
            alpha -= 10;
        }


    }

    void PlayFinFin() {
        chapterQuoteText.text = "Did you make the right ones?";
        StartCoroutine(FadeTextInEnding(chapterQuoteText));
        Invoke("CanGoBackToMenu",2.0f);
        
    }

    void CanGoBackToMenu() {
        canEnd = 3;
        chapterCont.enabled = true;
        StartCoroutine(FadeTextInEnding(chapterCont));
    }



    public void Update() {
        if (Input.GetAxis("Action") == 1) {
            if (isActionInUse == false) {
                isActionInUse = true;

                if (canEnd == 1) {
                    canEnd = 2;
                    PlayFin();
                } else if (canEnd == 3) {
                    SceneManager.LoadScene(0);
                }

                

            }
        }

        if (Input.GetAxis("Action") == 0) {
            isActionInUse=false;
        }
    }
















    //General ftions
    void ToggleAllBarPeople(bool temp) {
        if (temp) {
            // enable all childeren
            for (int i = 0; i < barPeople.transform.childCount; i++) {
            
                barPeople.transform.GetChild(i).gameObject.SetActive(true);
            }
        } else {
            // disable all childeren
            for (int i = 0; i < barPeople.transform.childCount; i++) {
            
                barPeople.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void ToggleAllHallPeople(bool temp) {
        if (temp) {
            // enable all childeren
            for (int i = 0; i < hallPeople.transform.childCount; i++) {
            
                hallPeople.transform.GetChild(i).gameObject.SetActive(true);
            }
        } else {
            // disable all childeren
            for (int i = 0; i < hallPeople.transform.childCount; i++) {
            
                hallPeople.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }


    //Standard Start and End Dialogs

    public void StartDialogNameNeeded() {
        dialogManager.story.variablesState["player_name"] = GameObject.Find("Player").GetComponent<PlayerSprite>().playerName;

        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
    }



    public void StartDialogTwoNamesNeeded() {
        dialogManager.story.variablesState["player_name"] = GameObject.Find("Player").GetComponent<PlayerSprite>().playerName;
        dialogManager.story.variablesState["victimName"] = GameObject.Find("StoryManager").GetComponent<StoryProgress>().trialVictimName;

        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.right);
    }




    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
    }

}
