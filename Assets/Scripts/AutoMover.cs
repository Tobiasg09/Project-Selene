using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMover : MonoBehaviour
{
    private bool canWalk = false;
    private Vector3 moveDirection;
    private float moveSpeed = 0;
    
     void FixedUpdate() {

        if (canWalk) {
            Vector3 targetPosition = transform.position + moveDirection;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        }
    }


    public void MovePersonTimed(Vector3 direction, float moveVel, float time) {
//Ideally, direction should be transform.up, right, -up or -right
//Will move character to that direction for x amount of seconds
//combine this with playeranimator or characteranimator for best results
    canWalk = true;
    Invoke("StopTimedWalk",time);
    moveSpeed = moveVel;
    moveDirection = direction;


    }

    void StopTimedWalk() {
        canWalk = false;
    }



    
}
