using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    private SpriteRenderer sr;
    public bool leftRoom = true;
    public string backgroundMusic = "none";


    void Start() {
        StartCoroutine(ToggleActiveAllChildren(false, 0.0f));
    }



    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "PlayerSight") {
            leftRoom = true;
            StartCoroutine(ToggleActiveAllChildren(false, 0.2f));

        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "PlayerSight") {
            leftRoom = false;
            StartCoroutine(ToggleActiveAllChildren(true, 0.0f));

        }

        if(other.gameObject.tag == "PlayerFeet") {
            if (backgroundMusic != "none") {
                FindObjectOfType<AudioManager>().PlayBackgroundMusic(backgroundMusic);
            }
        }

    }


    public IEnumerator ToggleActiveAllChildren(bool temp, float waitTime) {
        yield return new WaitForSeconds(waitTime);
        if (temp) {
            // enable all childeren
            for (int i = 0; i < gameObject.transform.childCount; i++) {
            
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        } else {
            //disable all childeren. always disable all
            if (leftRoom) {
                for (int i = 0; i < gameObject.transform.childCount; i++) {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
}
