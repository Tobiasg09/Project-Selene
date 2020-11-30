using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //for image manipulation
using UnityEngine.SceneManagement; //for scene manipulation
using TMPro; //for TMPro

public class Chapter1Progress : MonoBehaviour
{
    public StoryProgress storyProgress;
    private int chapter;

    public GameObject blackScreen;
    public TextAsset dialogWakeUp;
    public TextAsset dialogWakeUp1;
    public TextAsset dialogExitRoom;
    public TextAsset dialogExitRoom1;

    //ChapterScreen variables//
    public GameObject chapterScreen;
    public TextMeshProUGUI chapterText;
    public TextMeshProUGUI chapterQuoteText;

    // Introduction variables //
    public bool isActionInUse = false;
    public GameObject introPanel;
    public int introPlaying = 0; //0 is not playing. 1 is playing. 2 is finished playing and waiting for action.
    public bool skipIntro = false;
    public TextMeshProUGUI introText1;
    public TextMeshProUGUI introText2;
    public TextMeshProUGUI introText3;
    public TextMeshProUGUI introText4;
    public TextMeshProUGUI introCont;
    public TextMeshProUGUI introInfo;

    //Exitroom hallway variables //
    public Transform SpawnPlayerIntro;
    public GameObject AndyExitRoom;
    public GameObject CharlotteExitRoom;
    private bool finishedTalkingToFriends = false;
    public GameObject CharlotteHallway;
    public GameObject KeranHallway;
    public GameObject HumairaHallway;
    public GameObject JabariHallway;

    public GameObject hallPeople;
    public GameObject ConciergeHallway;

    //Enter Bar variables
    public GameObject barPeople;
    public TextAsset dialogEnterBar0;
    public TextAsset dialogEnterBar1;
    public GameObject peopleWatchingElection;
    public GameObject peopleIntroBlock;
    public GameObject newsScreen;

    public TextAsset dialogEnterBar2;
    public GameObject kwameIntro;
    

    // Nitrogen quest variables //
    public bool questNitrogenStarted = false;
    public bool questNitrogenDoing = false;

    private DialogManager dialogManager;
    private int alpha;
    private float fadeSpeed = 0.01f; //high number is slower
    private bool playerFemale = true; 

    public TextAsset dialogEnterChemLab;
    public TextAsset dialogEnterChemLab1;

    public GameObject C1_NitroQuest_ChemistBlockingEntrance;
    public GameObject ChemLab_Nitrogen;
    public bool hasNitrogen = false;

    public Transform respawnPositionChemLab;

    public bool questNitrogenFinished = false;

    public TextAsset dialogNitroQuestReminder;



    // Electricity quest variables //
    public GameObject C1_ElecQuest_Andy;
    public int elecQuestProgress = 0; //0 is not yet started. At every stage, do +1. -1 if completed.
    public GameObject Andy_C1_ElecQuest_WalkInto;
    public GameObject maintenanceRoomLever;
    public TextAsset dialogStartC1ElecQuest;
    public TextAsset dialogStartC1ElecQuest1;
    public TextAsset dialog_C1ElecQuest_Andy_S1;
    public TextAsset dialog_C1ElecQuest_Computer;
    public TextAsset dialog_C1ElecQuest_Andy_S2;
    public TextAsset dialog_C1ElecQuest_Andy_S3;
    public TextAsset dialog_C1ElecQuest_BedroomTrigger;
    public GameObject quantumCore;
    public TextAsset dialog_C1ElectQuest_FoundCore;
    public TextAsset dialog_C1ElecQuest_QuantumCoreInstalled;
    public TextAsset dialog_C1ElectQuest_Final;



    //Epilogue variables
    public bool startedEpilogue = false;
    public bool startedEpilogue2 = false;
    public TextAsset dialog_C1StartEpilogue;
    public Transform spawnInBarEpilogue;
    public TextAsset dialog_C1_Epilogue;
    public GameObject PeopleEpilogue;



    //Concierge
    public TextAsset C1_DialogReminderConcierge;





    void Awake() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        storyProgress = GameObject.Find("StoryManager").GetComponent<StoryProgress>();
    }

    
    //WAKE UP IN ROOM

    public void StartChapter() {
        //Activate all Chapter1's in every room
        GameObject[] Chapter1GOs = storyProgress.Chapter1GOs;
        foreach (GameObject Chapter1GO in Chapter1GOs) {
            Chapter1GO.SetActive(true); 
        }


        // Disable all GO's that need to appear during quests
        Andy_C1_ElecQuest_WalkInto.SetActive(false);
        PeopleEpilogue.SetActive(false);

        blackScreen.SetActive(true);
        blackScreen.GetComponent<Image>().color = new Color32(0,0,0,255); //set it to black 
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(SpawnPlayerIntro, false);


        FindObjectOfType<AudioManager>().ToggleCanPlayBackgroundMusic(false);
        chapterScreen.SetActive(true);
        chapterText.text = "Chapter 1";
        chapterQuoteText.text = "A journey of a thousand miles begins with a single step. \n              ~ Laozi";
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
        
        StartIntro();
        chapterScreen.SetActive(false);
    }

    void StartIntro() {
        introPanel.SetActive(true);
        introPlaying = 1;
        FindObjectOfType<AudioManager>().ToggleCanPlayBackgroundMusic(true);
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Intro",true);
        StartCoroutine(FadeTextIn(introText1, 0.1f, 1.0f));
        StartCoroutine(FadeTextIn(introText2, 0.1f, 6.0f));
        StartCoroutine(FadeTextIn(introText3, 0.1f, 11.0f));
        StartCoroutine(FadeTextIn(introText4, 0.1f, 16.0f));
        StartCoroutine(FadeTextIn(introCont, 0.1f, 18.0f));
        StartCoroutine(FadeTextIn(introInfo, 0.1f, 18.0f));
        Invoke("IntroCanCont", 18.0f);
    }



    public void IntroCanCont() {
        if (introPlaying == 1) { //so only do this if intro is still playing.
            introPlaying = 2;
        }
    }


    public IEnumerator FadeTextIn(TextMeshProUGUI text, float fadeVel = 0.1f, float waitTime = 0.0f ) {
        text.color = new Color32(255,255,255,0);
        yield return new WaitForSeconds(waitTime);
        int alpha=0;
        while (alpha < 255) {
            if (skipIntro == false) {
                text.color = new Color32(255,255,255,(byte)alpha);
                yield return new WaitForSeconds(fadeVel);
            }
            alpha += 10;
        }
    }

    void SkipIntro() {
        Invoke("IntroCanCont",1.0f);
        introText1.color = new Color32(255,255,255,255);
        introText2.color = new Color32(255,255,255,255);
        introText3.color = new Color32(255,255,255,255);
        introText4.color = new Color32(255,255,255,255);
        introCont.color = new Color32(255,255,255,255);
        introInfo.color = new Color32(255,255,255,255);
    }


    void StartChapter1() {
        introPanel.SetActive(false);
        FindObjectOfType<AudioManager>().StopOverwriteMusic();
    
        dialogManager.Talk(dialogWakeUp, StartDialog, EndDialogWakeUp);

    }


    public IEnumerator FadeIn() {
        alpha=255;
        Image image = blackScreen.GetComponent<Image>();
        while (alpha != 0) {
            alpha -= 1;
            image.color = new Color32(0,0,0,(byte)alpha);
            yield return new WaitForSeconds(fadeSpeed);
        }
        blackScreen.SetActive(false);
    }


    public void EndDialogWakeUp() {
        StartCoroutine(FadeIn());
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Main");
        playerFemale = (int) dialogManager.story.variablesState["Female"] == 1 ? true : false;
        if (playerFemale) {
            GameObject.Find("Player").GetComponent<PlayerSprite>().playerFemale = true;
        } else {
            GameObject.Find("Player").GetComponent<PlayerSprite>().playerFemale = false;
        }
        dialogManager.Talk(dialogWakeUp1, StartDialog, EndDialog);
    }


    /// EXITING ROOM 

    public void TriggeredMyRoom() {
        dialogManager.Talk(dialogExitRoom, StartDialog, EndDialogExitRoom);
    }

    public void EndDialogExitRoom() {
        AndyExitRoom.GetComponent<Patroller>().patrolable = true;
        CharlotteExitRoom.GetComponent<Patroller>().patrolable = true;
        StartCoroutine(FinishExitRoom());
    }
    

    IEnumerator FinishExitRoom() {
        yield return new WaitForSeconds(1.0f);
        dialogManager.Talk(dialogExitRoom1, StartDialog, EndDialogExitRoom1);
        yield return new WaitForSeconds(2.0f);
        Destroy(AndyExitRoom);
        Destroy(CharlotteExitRoom);
        //CharlotteHallway.SetActive(false);
        //KeranHallway.SetActive(false);
        //HumairaHallway.SetActive(false);
        //JabariHallway.SetActive(false);

        ToggleAllHallPeople(false);
        ConciergeHallway.SetActive(true);

        if (finishedTalkingToFriends) {
            GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
            GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
        }
        finishedTalkingToFriends = true;
    }

    
    public void EndDialogExitRoom1() {
        if (finishedTalkingToFriends) {
            GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
            GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
        }
        finishedTalkingToFriends = true;
        ToggleAllBarPeople(false);
        peopleWatchingElection.SetActive(true);
        peopleIntroBlock.SetActive(true);
        
    }


    // ENTERING BAR

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

    public void EnteredBar() {
        dialogManager.Talk(dialogEnterBar0, StartDialog, EndDialog);
    }

    public void EnteredBar1() {
        dialogManager.Talk(dialogEnterBar1, StartDialog, EndDialogBarIntro);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.up,0.1f);
        kwameIntro.GetComponent<CharacterAnimator>().TurnCharToward(transform.up);
    }

    public void EndDialogBarIntro() {
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,5,0.5f);
        Invoke("EndBarIntro",0.5f);
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true,0.5f);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true,0.5f);
    }

    public void EndBarIntro() {
        ToggleAllBarPeople(true);
        //CharlotteHallway.SetActive(true);
        //KeranHallway.SetActive(true);
        //JabariHallway.SetActive(true);
        //HumairaHallway.SetActive(true);

        ToggleAllHallPeople(true);
        Destroy(peopleWatchingElection);
        Destroy(peopleIntroBlock);
        Destroy(newsScreen);
        GameObject.Find("EnterBarTrigger2").GetComponent<EnterBar2Trigger>().introOver = true;
    }

    public void EnteredBar2() {
        C1_ElecQuest_Andy.GetComponent<CharacterAnimator>().TurnCharToward(transform.right);
        dialogManager.Talk(dialogEnterBar2, StartDialog, EndDialog);
    }





// NITROGEN QUEST

    public void EnteredChemLab() {
        dialogManager.Talk(dialogEnterChemLab, StartDialog, EndDialogEnterChem);
    }

    public void EndDialogEnterChem() {
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,10,1);
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
        Destroy(C1_NitroQuest_ChemistBlockingEntrance, 1.0f);
        Invoke("EnteredChemLab1",1.0f);
    }

    public void EnteredChemLab1() {
        dialogManager.Talk(dialogEnterChemLab1, StartDialog, EndDialog);
    }


    public void TookNitrogen() {
        hasNitrogen = true;
        ChemLab_Nitrogen.SetActive(false);
    }

    public void DetectedByChemist() {
        hasNitrogen = false;
        ChemLab_Nitrogen.SetActive(true);

        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(respawnPositionChemLab);
    }

    public void NitroQuestReminder(){
        dialogManager.Talk(dialogNitroQuestReminder, StartDialog, EndDialog);
    }



// ELECTRICITY QUEST

    public void StartedElecQuest() {
        elecQuestProgress = 1;
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
        dialogManager.Talk(dialogStartC1ElecQuest, StartDialog, EndDialogStartElecQuest);
    }

    public void EndDialogStartElecQuest() {
        Invoke("ReactOnDarkLight",0.7f);
    }

    public void ReactOnDarkLight() {
        blackScreen.SetActive(true);
        Image image = blackScreen.GetComponent<Image>();
        image.color = new Color32(0,0,0,150);

        dialogManager.Talk(dialogStartC1ElecQuest1, StartDialog, EndDialog);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);

    }

    public void TalkAndy_S1() {
        dialogManager.Talk(dialog_C1ElecQuest_Andy_S1, StartDialog, EndDialog);
        
    }

    public void FoundComputer() {
        elecQuestProgress = 2;
        dialogManager.Talk(dialog_C1ElecQuest_Computer, StartDialog, EndDialog);
    }

    public void FoundIssue() {
        elecQuestProgress = 3;
        dialogManager.Talk(dialog_C1ElecQuest_Andy_S2, StartDialog, EndDialog);
    }

    public void TalkAndy_S3() {
        dialogManager.Talk(dialog_C1ElecQuest_Andy_S3, StartDialog, EndDialog);
    }

    public void QuantumCoreTrigger() {
        dialogManager.Talk(dialog_C1ElecQuest_BedroomTrigger, StartDialog, EndDialog);
    }

    public void FoundQuantumCore() {
        elecQuestProgress = 4;
        quantumCore.GetComponent<QuantumCore>().foundCore = true;
        dialogManager.Talk(dialog_C1ElectQuest_FoundCore, StartDialog, EndDialog);

    }

    public void QuantumCoreInstalled() {
        dialogManager.Talk(dialog_C1ElecQuest_QuantumCoreInstalled, StartDialog, EndDialogCoreInstalled);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
    }

    public void EndDialogCoreInstalled() {
        Destroy(maintenanceRoomLever);
        Image image = blackScreen.GetComponent<Image>();
        image.color = new Color32(0,0,0,0);
        blackScreen.SetActive(false);
        Andy_C1_ElecQuest_WalkInto.SetActive(true);
        Andy_C1_ElecQuest_WalkInto.GetComponent<Patroller>().patrolable = true;
        Invoke("AndyAppear",1.0f);
    }

    public void AndyAppear() {
        Andy_C1_ElecQuest_WalkInto.GetComponent<Patroller>().TogglePausePatrol(true);
        dialogManager.Talk(dialog_C1ElectQuest_Final, StartDialog, EndDialogElecQuestEnding);
    }

    public void EndDialogElecQuestEnding() {
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,10,1);
        Destroy(Andy_C1_ElecQuest_WalkInto,1.0f);
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true,1.5f);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true,1.5f);
        elecQuestProgress = -1;
    }






    public void Update() {
        //If during intro, if can continue from and press action, contiue
        if (Input.GetAxis("Action") == 1) {
            if (isActionInUse == false) {
                isActionInUse = true;

                if (introPlaying == 2) {
                    introPlaying = 0;
                    StartChapter1(); 
                    
                }

                if (introPlaying == 1) {
                    skipIntro = true;
                    SkipIntro();
                }
            }
        }

        if (Input.GetAxis("Action") == 0) {
            isActionInUse=false;
        }

        // IF DONE BOTH MISSIONS - SEE IF PLAYER CAN TALK EVERY 30 SECONDS UNTIL HE CAN AND THEN DO GENERAL ASSEMBLY IN BAR
        if ( (elecQuestProgress == -1) && (questNitrogenFinished) ) {
            if (startedEpilogue == false) {
                startedEpilogue = true;
                StartCoroutine(StartEpilogue());

            }
        }
    }

    


    IEnumerator StartEpilogue() {
        while (startedEpilogue2 == false) {
            yield return new WaitForSeconds(20.0f);
            dialogManager.Talk(dialog_C1StartEpilogue, StartDialogEpilog, EndDialogEpilogueStarted);
        }
    }

    void StartDialogEpilog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Crisis",true);
    }

    public void EndDialogEpilogueStarted() {
        startedEpilogue2 = true;
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,10,2);
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(spawnInBarEpilogue);
        Invoke("Epilogue",1.0f);

    }

    public void Epilogue() {
        ToggleAllBarPeople(false);
        PeopleEpilogue.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.up,0.1f);
        dialogManager.Talk(dialog_C1_Epilogue, StartDialog, EndDialogEpilogue);
    }

    public void EndDialogEpilogue() {
        StartCoroutine(FadeOut());
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;
        GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter = chapter + 1;
        GameObject.Find("StoryManager").GetComponent<StoryProgress>().SaveProgress();
        Invoke("ReloadScene",3.0f);
    }

    public IEnumerator FadeOut() {
        blackScreen.SetActive(true);
        alpha=0;
        Image image = blackScreen.GetComponent<Image>();
        image.color = new Color32(0,0,0,0);
        while (alpha != 255) {
            alpha += 1;
            image.color = new Color32(0,0,0,(byte)alpha);
            yield return new WaitForSeconds(fadeSpeed);
        }
        //blackScreen.SetActive(false);
    }

    public void ReloadScene() {
        FindObjectOfType<AudioManager>().StopOverwriteMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    //Standard Start and End Dialogs

    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
    }





    // Reminder concierge

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


    public void ReminderConcierge() {
        dialogManager.Talk(C1_DialogReminderConcierge, StartDialog, EndDialog);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.right,0.1f);
    }






}
