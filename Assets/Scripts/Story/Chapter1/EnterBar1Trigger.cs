using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBar1Trigger : MonoBehaviour
{
    public GameObject chapter1;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "PlayerFeet") {
            chapter1.GetComponent<Chapter1Progress>().EnteredBar1();
            Destroy(this);
        }


    }
}
