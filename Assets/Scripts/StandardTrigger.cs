using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events; //for the UnityEvent

public class StandardTrigger : MonoBehaviour
{
    public UnityEvent triggerFunction;
    public GameObject detector;
    public bool destroyAfterTrigger = false;

     void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == detector) {
            Debug.Log("Triggered");
            triggerFunction.Invoke();

            if (destroyAfterTrigger) {
                GameObject.Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject == detector) {
            Debug.Log("Triggered");
            triggerFunction.Invoke();

            if (destroyAfterTrigger) {
                GameObject.Destroy(gameObject);
            }
        }
    }



    
}
