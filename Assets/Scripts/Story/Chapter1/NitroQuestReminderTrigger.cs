using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroQuestReminderTrigger : MonoBehaviour
{
    public GameObject chapter1;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "MainCharacter") {

            if (chapter1.GetComponent<Chapter1Progress>().hasNitrogen) {
                chapter1.GetComponent<Chapter1Progress>().NitroQuestReminder();
                Destroy(this);
            }
        }


    }
}
