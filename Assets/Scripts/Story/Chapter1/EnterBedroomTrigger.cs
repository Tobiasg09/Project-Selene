using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBedroomTrigger : MonoBehaviour
{
    public GameObject chapter1;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "MainCharacter") {

            if (chapter1.GetComponent<Chapter1Progress>().elecQuestProgress == 3) {
                chapter1.GetComponent<Chapter1Progress>().QuantumCoreTrigger();
                Destroy(this);
            }
        }


    }
}
