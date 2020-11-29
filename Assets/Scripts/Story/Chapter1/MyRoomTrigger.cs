using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRoomTrigger : MonoBehaviour
{
    public GameObject chapter1;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "MainCharacter") {
            chapter1.GetComponent<Chapter1Progress>().TriggeredMyRoom();
            Destroy(this);
        }


    }



}
