using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events; //for the UnityEvent


// Just attach this script to any object that can patrol, and select the function (in a different script) that find the patrolpath
public class Patroller : MonoBehaviour
{
    public bool patrolable = true; //if false it cannot patrol
    public UnityEvent givePatrolpath;
    public float patrolPrecision = 0.2f;
    public float moveSpeed = 5.0f; //change this to include in the patrol!

    private bool patrolling = false; //if currently patrolling
    private Queue<PatrolPoint> targets; //queue for all the patrol targets;

    private PatrolPoint currTarget;
    private bool currTargetKnown = false;

    private bool pausePatrol = false;

    // Start is called before the first frame update
    void Start()
    {
        targets = new Queue<PatrolPoint>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (patrolable) { //if it is not patrolling and can patrol, find a patrolpath
            if (patrolling == false) {
                givePatrolpath.Invoke();
            }
        }
    }

    void FixedUpdate() {
        if (currTargetKnown) {
            if (pausePatrol == false) {
                transform.position = Vector2.MoveTowards(transform.position, currTarget.coordinates.position, moveSpeed * Time.fixedDeltaTime);
                if (Vector2.Distance(transform.position, currTarget.coordinates.position) < 0.2f) {
                    currTargetKnown = false;
                    Invoke("GoToNextTarget",currTarget.waitTime);

                }
            }
        }
        
    }

    public void StartPatrol(Patrol patrolPath) {
        patrolling = true;
        targets.Clear(); //clear your path

        foreach (PatrolPoint target in patrolPath.patrolPoints) {
            
            targets.Enqueue(target);
        }

        if (patrolPath.isLoop) {
            for (int i = patrolPath.patrolPoints.Length - 2; i >= 1; i--) { //we don't want the first and last patrolpoint anymore

                targets.Enqueue(patrolPath.patrolPoints[i]);
            }
        }

        GoToNextTarget();
    }

    void GoToNextTarget() {
        if (targets.Count == 0) { //means we're at the end of the patrol
            patrolling = false;
            return;

        } else {
            currTarget = targets.Dequeue();
            currTargetKnown = true;
        }
    }


    public Transform WhatIsNextPatrolPoint() { //public function that other can call to return the next patrol point if it is patrolling
        if (patrolling) {
            return currTarget.coordinates;
        }
        return transform;
    }


    public void TogglePausePatrol(bool pausePatrolTemp) { //public functoin that can be called to toggle pausePatrol. If true, it will pause the patrol. The patrol will be resumed if pausepatrol is false
        if (pausePatrolTemp) {
            pausePatrol = true;
        } else {
            pausePatrol = false;
        }
    }
}
