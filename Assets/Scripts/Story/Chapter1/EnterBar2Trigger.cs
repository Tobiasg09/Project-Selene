using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBar2Trigger : MonoBehaviour
{
    public GameObject chapter1;
    public bool introOver = false;

    void OnTriggerEnter2D(Collider2D other){
        if (introOver) {
            if (other.gameObject.tag == "PlayerFeet") {
            chapter1.GetComponent<Chapter1Progress>().EnteredBar2();
            Destroy(this);
            }
        }
        


    }
}
