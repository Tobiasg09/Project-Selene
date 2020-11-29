using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{

    private Vector3 prevPos = Vector2.zero;

    private Animator animator;
    

    //This script can be attached to any character with an animator to directly control its animations w/o need 
    //of user input. Can also be used for players during cutscenes! 


    void Awake() {
        animator = GetComponent<Animator>();
    }



    void FixedUpdate()
    {
        //FromWhichDirection will return transform.up, transform.right etc depending on which direction you're going to.
        Vector3 direction = GameObject.Find("Utils").GetComponent<Utilities>().FromWhichDirection(prevPos, transform.position);


        ManipulateAnimator(direction);

        prevPos = transform.position; //last bit in fixedupdate
    }


    void ManipulateAnimator(Vector3 direction){
        
        if (direction == transform.up) {
            animator.SetInteger("direction", 1);
            animator.speed = 1.0f;
        }

        else if (direction == -transform.up) {
            animator.SetInteger("direction", 2);
            animator.speed = 1.0f;
        }

        else if (direction == transform.right) {
            animator.SetInteger("direction", 0);
            GetComponent<SpriteRenderer>().flipX = false;
            animator.speed = 1.0f;
        }

        else if (direction == -transform.right) {
            animator.SetInteger("direction", 0);
            GetComponent<SpriteRenderer>().flipX = true;
            animator.speed = 1.0f;
        }

        else if (direction == Vector3.zero) {
            if (animator.GetInteger("direction") == 0) {
                animator.SetInteger("direction", -1);
            }
            else {
                animator.speed = 0.0f;
            }
           
        }
        
    }



    //public function to turn character around

    public void TurnCharToward(Vector3 direction, float waitTime = 0.0f) {
        StartCoroutine(TurnTowardHelper(direction, waitTime));
    }

    IEnumerator TurnTowardHelper(Vector3 direction, float waitTime) {
        yield return new WaitForSeconds(waitTime);

        if (direction == transform.up) {
            animator.SetInteger("direction", 1);
        }

        if (direction == -transform.up) {
            animator.SetInteger("direction", 2);
        }

        if (direction == transform.right) {
            animator.SetInteger("direction", 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (direction == -transform.right) {
            animator.SetInteger("direction", 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }



}
