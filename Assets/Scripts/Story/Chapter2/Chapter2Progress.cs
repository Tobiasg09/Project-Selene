using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //for image manipulation
using UnityEngine.SceneManagement; //for scene manipulation
using TMPro; //for TMPro

public class Chapter2Progress : MonoBehaviour
{

    private DialogManager dialogManager;
    private StoryProgress storyProgress;
    private int chapter;

    public GameObject barPeople;
    public GameObject blackScreen;

    //ChapterScreen variables//
    public GameObject chapterScreen;
    public TextMeshProUGUI chapterText;
    public TextMeshProUGUI chapterQuoteText;
    

    // All introduction quest variables //

    public TextAsset C2_Intro_DialogWakeUp;
    public Transform C2_Intro_SpawnPlayer;
    public GameObject C2_Intro_BarPeople;


    // All trial quest variables //
    public int C2_TriaQuest_Progress = 0;
    public GameObject C2_TriaQuest_ExitBarBlock;
    public TextAsset C2_TriaQuest_DialogExitBar0;
    public TextAsset C2_TriaQuest_DialogExitBar1;
    public TextAsset C2_TriaQuest_DialogBartender;
    public TextAsset C2_TriaQuest_DialogAndy;
    public TextAsset C2_TriaQuest_DialogAndyDoingQuest;
    public TextAsset C2_TriaQuest_DialogAndyFinishedQuestioning;
    public TextAsset C2_TriaQuest_DialogKwame;
    public TextAsset C2_TriaQuest_DialogCharlotte;
    public TextAsset C2_TriaQuest_DialogMei;
    public TextAsset C2_TriaQuest_DialogPiotr;
    public GameObject C2_TriaQuest_PeopleTrial;
    public TextAsset C2_TriaQuest_DialogTrial;
    public Transform C2_TriaQuest_spawnTrial;
    public Transform C2_TriaQuest_spawnEndTrial;
    public TextAsset C2_TriaQuest_DialogEnding;
    public TextAsset C2_TriaQuest_DialogEnding1;
    public GameObject C2_TriaQuest_CharlotteEnding;

    public bool C2_TriaQuest_talkedToKwame = false;
    public bool C2_TriaQuest_talkedToCharlotte = false;
    public bool C2_TriaQuest_talkedToMei = false;
    public bool C2_TriaQuest_talkedToPiotr = false;

    //All explore lunar surface variables //
    public int C2_SurfQuest_Progress = 0;
    public TextAsset C2_SurfQuest_DialogStart;
    public GameObject C2_SurfQuest_ExitBioLabTrigger;
    public GameObject C2_SurfQuest_NPC;
    public TextAsset C2_SurfQuest_DialogTeleport;
    public TextAsset C2_SurfQuest_DialogArrive;
    public Transform C2_SurfQuest_spawnStateBaseOutdoor;
    public TextAsset C2_SurfQuest_DialogNotAbleTeleport;
    public GameObject C2_SurfQuest_Mines;
    public TextAsset C2_SurfQuest_DialogAlyssa;
    public TextAsset C2_SurfQuest_DialogAlyssaDirections;
    public GameObject C2_SurfQuest_Alyssa;
    public GameObject C2_SurfQuest_VLAlyssa;
    public TextAsset C2_SurfQuest_DialogControlbox;
    public Transform C2_SurfQuest_spawnAlyssaFront;
    public TextAsset C2_SurfQuest_DialogAlyssaFinished;
    public GameObject C2_SurfQuest_Controlbox;

    



    // All epilog variables //
    public GameObject C2_EpilogcharlotteWaiting;
    public GameObject C2_Epilog_CharlotteHall;
    public GameObject C2_Epilog_ExitMoonBlock;
    public TextAsset C2_Epilog_DialogStart;
    public TextAsset C2_Epilog_DialogCharlotte;


    void Awake() {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
        storyProgress = GameObject.Find("StoryManager").GetComponent<StoryProgress>();
    }

    void Update() {
        if (C2_TriaQuest_Progress == -1 || GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter > 2) {
            KillTrialVictim(); //maybe instead of doing this every update frame, put in room transition?
        }
    }


    public void KillTrialVictim() {
        string trialVictimName = GameObject.Find("StoryManager").GetComponent<StoryProgress>().trialVictimName;
        GameObject[] trialVictimGOs = GameObject.FindGameObjectsWithTag(trialVictimName);
        foreach (GameObject trialVictimGO in trialVictimGOs) {
            Destroy(trialVictimGO);
        }
    }



     public void StartChapter() {
        //Activate all Chapter2's in every room
        GameObject[] Chapter2GOs = storyProgress.Chapter2GOs;
        foreach (GameObject Chapter2GO in Chapter2GOs) {
            Chapter2GO.SetActive(true); 
        }


        // Disable all GO's that need to appear during quests
        C2_TriaQuest_PeopleTrial.SetActive(false);
        C2_TriaQuest_CharlotteEnding.SetActive(false);
        C2_SurfQuest_NPC.SetActive(false);
        C2_EpilogcharlotteWaiting.SetActive(false);



        //Enable all GO's that need to appear during this chapter


        FindObjectOfType<AudioManager>().ToggleCanPlayBackgroundMusic(false);
        blackScreen.SetActive(true);
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(C2_Intro_SpawnPlayer, false);
        blackScreen.GetComponent<Image>().color = new Color32(0,0,0,255); //set it to black 


        chapterScreen.SetActive(true);
        chapterText.text = "Chapter 2";
        chapterQuoteText.text = "Is man merely a mistake of God's? Or God merely a mistake of man's? \n~ Friedrich Nietzsche";
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
            
            alpha += 5;
        }
        yield return new WaitForSeconds(midWaitTime);
        
        alpha = 255;
        while (alpha > 0) {
            text.color = new Color32(255,255,255,(byte)alpha);
            yield return new WaitForSeconds(fadeVel);    
            alpha -= 5;
        }

        //if finish, start the rest.
        StartChapterReal();
        chapterScreen.SetActive(false);
    }

    void StartChapterReal() {
        FindObjectOfType<AudioManager>().ToggleCanPlayBackgroundMusic(true);
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Crisis",true);
        ToggleAllBarPeople(false);
        C2_Intro_BarPeople.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.up,0.1f);
        
        StartCoroutine(FadeIn());
        dialogManager.Talk(C2_Intro_DialogWakeUp, StartDialog, EndDialogIntro);

        C2_TriaQuest_Progress = 1;
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


    void EndDialogIntro() {
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,10,1);
        Invoke("EndIntro",1.0f);
        FindObjectOfType<AudioManager>().StopOverwriteMusic();
    }

    void EndIntro() {
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Main");
        ToggleAllBarPeople(true);
        C2_Intro_BarPeople.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
    }

    // Trial Quest

    public void CannotExitBarYet() {
        if (C2_TriaQuest_Progress == 1) {
            dialogManager.Talk(C2_TriaQuest_DialogExitBar0, StartDialog, EndDialog);
        }

        if (C2_TriaQuest_Progress == 2) {
            dialogManager.Talk(C2_TriaQuest_DialogExitBar1, StartDialogNameNeeded, EndDialog);
        }
    }

    public void TalkBartender() {
        dialogManager.Talk(C2_TriaQuest_DialogBartender, StartDialogNameNeeded, EndDialogTrialBartender);
        //GameObject.Find("Player").GetComponent<PlayerMovement>().isDrunk = true;
        C2_TriaQuest_Progress = 2;
    }

    void EndDialogTrialBartender() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
        bool C2_TriaQuest_DrankAlcohol = (int) dialogManager.story.variablesState["alcohol"] == 1 ? true : false;    
        if (C2_TriaQuest_DrankAlcohol) {
            GameObject.Find("Player").GetComponent<PlayerMovement>().isDrunk = true;
        }
    }


    public void TalkAndy() {
        if (C2_TriaQuest_Progress == 2) {
            dialogManager.Talk(C2_TriaQuest_DialogAndy, StartDialog, EndDialog);
            C2_TriaQuest_Progress = 3;
            Destroy(C2_TriaQuest_ExitBarBlock);
        }


        if ((C2_TriaQuest_talkedToKwame) && (C2_TriaQuest_talkedToCharlotte) && (C2_TriaQuest_talkedToMei) && (C2_TriaQuest_talkedToPiotr) && (C2_TriaQuest_Progress == 3)) {
            dialogManager.Talk(C2_TriaQuest_DialogAndyFinishedQuestioning, StartDialog, EndDialogCheckIfFinishedQuestioning);
        }

        

        if (C2_TriaQuest_Progress == 3) {
            dialogManager.Talk(C2_TriaQuest_DialogAndyDoingQuest, StartDialog, EndDialog);
        }
        
    }

    public void TalkKwame() {
        dialogManager.Talk(C2_TriaQuest_DialogKwame, StartDialog, EndDialog);
        C2_TriaQuest_talkedToKwame = true;
    }

    public void TalkCharlotte() {
        dialogManager.Talk(C2_TriaQuest_DialogCharlotte, StartDialog, EndDialog);
        C2_TriaQuest_talkedToCharlotte = true;
    }

    public void TalkMei() {
        dialogManager.Talk(C2_TriaQuest_DialogMei, StartDialog, EndDialog);
        C2_TriaQuest_talkedToMei = true;
    }

    public void TalkPiotr() {
        dialogManager.Talk(C2_TriaQuest_DialogPiotr, StartDialog, EndDialog);
        C2_TriaQuest_talkedToPiotr = true;
    }

    public void EndDialogCheckIfFinishedQuestioning() {
        bool C2_TriaQuest_Ready = (int) dialogManager.story.variablesState["ready"] == 1 ? true : false;
        if (C2_TriaQuest_Ready) {
            C2_TriaQuest_Progress = 4;
            GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,20,2);
            Invoke("StartTrial",1.0f);
        } else {
            EndDialog();
        }
    }

    public void StartTrial() {
        ToggleAllBarPeople(false);
        C2_TriaQuest_PeopleTrial.SetActive(true);
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Crisis",true);
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(C2_TriaQuest_spawnTrial, false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.up,0.1f);
        dialogManager.Talk(C2_TriaQuest_DialogTrial, StartDialogNameNeeded, EndDialogEndTrial);
    }

    public void EndDialogEndTrial() {
        GameObject.Find("StoryManager").GetComponent<StoryProgress>().trialVictimName = (string) dialogManager.story.variablesState["name_final_suspect"];
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,2,5,5);
        Invoke("EndQuestInBioRoom",4.0f);
        FindObjectOfType<AudioManager>().StopOverwriteMusic();
        C2_TriaQuest_CharlotteEnding.SetActive(true);
    }


    public void EndQuestInBioRoom() {
        FindObjectOfType<AudioManager>().PlayBackgroundMusic("Sad",true);
        GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(C2_TriaQuest_spawnEndTrial, false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.up);
        dialogManager.Talk(C2_TriaQuest_DialogEnding, StartDialogEnding, EndDialogInBioRoom);

    }

    public void StartDialogEnding(){
        Invoke("TurnCharlotteHelper",1.0f);
        dialogManager.story.variablesState["name_victim"] = GameObject.Find("StoryManager").GetComponent<StoryProgress>().trialVictimName;
    }

    void TurnCharlotteHelper() {
        C2_TriaQuest_CharlotteEnding.GetComponent<CharacterAnimator>().TurnCharToward(transform.up,0.1f);
    }

    public void EndDialogInBioRoom() {
        C2_TriaQuest_CharlotteEnding.GetComponent<AutoMover>().MovePersonTimed(-transform.up, 3.0f, 2.0f);
        Invoke("TrialQuestEndingHelper",0.4f);
        Invoke("DisableCharlotteTrialQuestEnding",0.8f);
    }

    void TrialQuestEndingHelper() {
        dialogManager.Talk(C2_TriaQuest_DialogEnding1, StartDialog, EndDialogTrialQuestEnding);
    }


    public void DisableCharlotteTrialQuestEnding() {
        C2_TriaQuest_CharlotteEnding.SetActive(false);
        C2_TriaQuest_Progress = -1;
        C2_SurfQuest_NPC.SetActive(true);
        C2_TriaQuest_PeopleTrial.SetActive(false);
        ToggleAllBarPeople(true);
        KillTrialVictim();
    }

    public void EndDialogTrialQuestEnding() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
        FindObjectOfType<AudioManager>().StopOverwriteMusic();
    }




    // Explore Lunar surface Quest

    public void StartSurfQuest() {
        if (C2_TriaQuest_Progress == -1) {
            C2_SurfQuest_NPC.SetActive(true);
            C2_SurfQuest_Progress = 1;
            C2_SurfQuest_Controlbox.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.right,0.1f);
            dialogManager.Talk(C2_SurfQuest_DialogStart, StartDialogNameNeeded, EndDialogStartSurfQuest);
            C2_SurfQuest_Mines.GetComponent<GroundTrigger_Mine>().isMine = true;
        }
    }

    void EndDialogStartSurfQuest() {
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,10,1);
        Invoke("RemoveStartNPC",0.5f);
    }

    void RemoveStartNPC() {
        Destroy(C2_SurfQuest_ExitBioLabTrigger);
        Destroy(C2_SurfQuest_NPC);
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
    }

    public void Teleport() {
        if (C2_SurfQuest_Progress == 1) {
            dialogManager.Talk(C2_SurfQuest_DialogTeleport, StartDialog, EndDialogTeleport);
        } 
        if (C2_SurfQuest_Progress == 2) {
            dialogManager.Talk(C2_SurfQuest_DialogNotAbleTeleport, StartDialog, EndDialog);
        }
        
    }

    public void EndDialogTeleport() {
        bool wantTeleport = (int) dialogManager.story.variablesState["wantTeleport"] == 1 ? true : false;
        if (wantTeleport) {
            GameObject.Find("Utils").GetComponent<Utilities>().RespawnPlayer(C2_SurfQuest_spawnStateBaseOutdoor);
            C2_SurfQuest_Progress = 2;
            Invoke("AfterTeleport",0.5f);
        } else {
            GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
            GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
        }
    }

    public void AfterTeleport() {
        dialogManager.Talk(C2_SurfQuest_DialogArrive, StartDialog, EndDialog);
    }

    public void TalkAlyssa() {
        if (C2_SurfQuest_Progress == 2) {
            dialogManager.Talk(C2_SurfQuest_DialogAlyssa, StartDialog, EndDialog);
            C2_SurfQuest_Progress = 3;
        }
        if (C2_SurfQuest_Progress == 3) {
            dialogManager.Talk(C2_SurfQuest_DialogAlyssaDirections, StartDialog, EndDialog);
        }
    }



    public void TalkControlBox() {
        dialogManager.Talk(C2_SurfQuest_DialogControlbox, StartDialog, EndDialogControlBox);
    }

    void EndDialogControlBox() {
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,10,1);
        Invoke("SpawnAlyssaToFront",0.5f);
    }

    public void SpawnAlyssaToFront() {
        C2_SurfQuest_Alyssa.transform.position = C2_SurfQuest_spawnAlyssaFront.position;
        C2_SurfQuest_Controlbox.GetComponent<SpriteRenderer>().enabled = true;
        Invoke("StartEndingSurfQuest",0.5f);
    }

    public void StartEndingSurfQuest() {
        dialogManager.Talk(C2_SurfQuest_DialogAlyssaFinished, StartDialogNameNeeded, EndDialogEndingSurfQuest);
    }

    void EndDialogEndingSurfQuest() {
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,10,1);
        Invoke("EndSurfQuestHelper",1.0f);
        C2_SurfQuest_Mines.GetComponent<GroundTrigger_Mine>().isMine = false;
        C2_EpilogcharlotteWaiting.SetActive(true);
        C2_Epilog_CharlotteHall.SetActive(false);
        C2_SurfQuest_Progress = -1;
        Invoke("EndDialog",0.5f);
    }

    void EndSurfQuestHelper() {
        Destroy(C2_SurfQuest_Alyssa);
        Destroy(C2_SurfQuest_VLAlyssa);
    }









    //Epilog functions




    public void StartEpilog() {
        if (C2_SurfQuest_Progress == -1 && C2_TriaQuest_Progress == -1) {
            dialogManager.Talk(C2_Epilog_DialogStart, StartDialogTwoNamesNeeded, EndDialogStartEpilog);
        }
    }

    public void StartDialogTwoNamesNeeded() {
        dialogManager.story.variablesState["player_name"] = GameObject.Find("Player").GetComponent<PlayerSprite>().playerName;
        dialogManager.story.variablesState["victim_name"] = GameObject.Find("StoryManager").GetComponent<StoryProgress>().trialVictimName;

        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().TurnPlayerToward(transform.right,0.1f);
        
    }
    

    public void EndDialogStartEpilog() {
        GameObject.Find("Utils").GetComponent<Utilities>().FadeOutFadeIn(0.01f,20,10,1);
        Invoke("EndDialog",1.0f);
        Destroy(C2_Epilog_ExitMoonBlock);
        Invoke("EndDialogHelper",1.0f);
    }

    void EndDialogHelper() {
    Destroy(C2_EpilogcharlotteWaiting);
    C2_Epilog_CharlotteHall.SetActive(true);
    }



  public void TalkCharlotteEpilog() {
        dialogManager.Talk(C2_Epilog_DialogCharlotte, StartDialogTwoNamesNeeded2, EndDialogEpilog);
    }

    public void StartDialogTwoNamesNeeded2() {
        dialogManager.story.variablesState["player_name"] = GameObject.Find("Player").GetComponent<PlayerSprite>().playerName;
        dialogManager.story.variablesState["victimName"] = GameObject.Find("StoryManager").GetComponent<StoryProgress>().trialVictimName;

        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
    }



    public void EndDialogEpilog() {
        StartCoroutine(FadeOut());
        chapter = GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter;
        GameObject.Find("StoryManager").GetComponent<StoryProgress>().chapter = chapter + 1;
        GameObject.Find("StoryManager").GetComponent<StoryProgress>().SaveProgress();
        Invoke("ReloadScene",3.0f);
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

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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


    //Standard Start and End Dialogs

    public void StartDialogNameNeeded() {
        dialogManager.story.variablesState["player_name"] = GameObject.Find("Player").GetComponent<PlayerSprite>().playerName;
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
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
