using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryProgress : MonoBehaviour
{
    public bool isDebug = false;
    public bool overrideChapter = false;
    public int chapter = 1;
    public GameObject chapter1;
    public GameObject chapter2;
    public GameObject chapter3;

    public GameObject[] storyGO;
    public GameObject[] Chapter1GOs;
    public GameObject[] Chapter2GOs;
    public GameObject[] Chapter3GOs;


    public string trialVictimName = "XXX";
    public bool hasEvacuated = false;


    //CHAPTER 1 VARIABLES
    



    // Start is called before the first frame update
    void Start()
    {
        if (isDebug) {
            Debug.Log("Debugging.");
            chapter = -1;
            //for (int i = 0; i < transform.childCount; i++) {
            //    Destroy(transform.GetChild(i).gameObject);
            //}
            //Destroy(this);
        }

        if (isDebug == false) {
            //Assume all Chapter GameObjects in every room are disabled. Thus, find all StoryGameObjects and activate all his children so as to get references to them.
            storyGO = GameObject.FindGameObjectsWithTag("StoryGameObject");
            foreach (GameObject sGO in storyGO){
                for (int i = 0; i < sGO.transform.childCount; i++) {
                    sGO.transform.GetChild(i).gameObject.SetActive(true);
                }
            }


            if (overrideChapter == false) {
                //load data
                chapter = PlayerPrefs.GetInt("Chapter",1);
                trialVictimName = PlayerPrefs.GetString("TrialVictimName","XXX");
                GameObject.Find("Player").GetComponent<PlayerSprite>().playerFemale = PlayerPrefs.GetInt("PlayerFemale",1)==1?true:false;

            }

            //First, disable every Chapter1 child of every room
            Chapter1GOs = GameObject.FindGameObjectsWithTag("Chapter1");
            foreach (GameObject Chapter1GO in Chapter1GOs) {
                Chapter1GO.SetActive(false); 
            }
            //Disable every Chapter2 child of every room
            Chapter2GOs = GameObject.FindGameObjectsWithTag("Chapter2");
            foreach (GameObject Chapter2GO in Chapter2GOs) {
                Chapter2GO.SetActive(false); 
            }
            //Disable every Chapter3 child of every room
            Chapter3GOs = GameObject.FindGameObjectsWithTag("Chapter3");
            foreach (GameObject Chapter3GO in Chapter3GOs) {
                Chapter3GO.SetActive(false); 
            }


            if (chapter == 1) {
                chapter1.GetComponent<Chapter1Progress>().StartChapter();
            }

            if (chapter == 2) {
                chapter2.GetComponent<Chapter2Progress>().StartChapter();
            }

            if (chapter == 3) {
                chapter3.GetComponent<Chapter3Progress>().StartChapter();
            }
        }


    }


    public void SaveProgress() {
        PlayerPrefs.SetInt("Chapter", chapter);
        PlayerPrefs.SetString("TrialVictimName", trialVictimName);
        PlayerPrefs.SetInt("PlayerFemale", GameObject.Find("Player").GetComponent<PlayerSprite>().playerFemale?1:0);
    }

}
