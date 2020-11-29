using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    
    private Vector2 movement;
    private Vector2 lastMovement;

    private bool canMove = true;
    public Animator animator;

    // drunk variables //
    public bool isDrunk = false;
    private bool firstDrink = true;
    private int xScramble;
    private int yScramble;
    // end drunk variables //


    // stairs variables //
    public bool isOnLadder = false;
    // end stairs variables //

    // icy variables //
    public bool isOnIce = false;
    private Vector2 lastPosition;
    private bool landedOnIce = true;
    // end ice variables //

    // detected variables //
    public bool detected = false;
    //end detected variables //

    //debug variables//
    public Vector2 testVector = new Vector2(1,0);
    // end debug variables//





    public Chapter3Progress chapter3Progress;


    void Awake() {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //Input
        if (canMove) {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical")*0.7f; //to create more depth, *0.7f
            movement.Normalize();

            if (isDrunk) {
                IsDrunk();
            }

            
        } else {
            movement.x = 0;
            movement.y = 0;
        }

        if (isOnIce) {
            movement = GameObject.Find("Utils").GetComponent<Utilities>().GetMainDirection(movement);
            IsOnIce();
        }


        ManipulateAnimator();
        PlayAudio();

    
        //These must be the very last things in each update
        lastMovement = movement;
        lastPosition = rb.position;
        if (Input.GetKeyDown("x")) {
            DebugPressed();    
        }
    }

    void PlayAudio() {
        if (isOnIce == false) { //no footsteps on ice
            if (lastMovement == Vector2.zero) {
                if (movement != Vector2.zero) { //means we started walking
                    FindObjectOfType<AudioManager>().Play("Walking");
                }
            }
        } else {
            FindObjectOfType<AudioManager>().Stop("Walking");
        }

            if (lastMovement != Vector2.zero) {
                if (movement == Vector2.zero) { //means we stopped walking
                    FindObjectOfType<AudioManager>().Stop("Walking");
                }
            }
        
    }




    void FixedUpdate() 
    {

        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    public void ToggleCanMove(bool canMoveTemp, float waitTime = 0.0f) { //public method that can be called to force the player to stop moving
        StartCoroutine(ToggleCanMoveHelper(canMoveTemp, waitTime));
    }

    IEnumerator ToggleCanMoveHelper(bool canMoveTemp, float waitTime) {
        yield return new WaitForSeconds(waitTime);
        if (canMoveTemp) {
            canMove = true;
        } else {
            canMove = false;
        }
    }





    //Script when player is drunk
    void IsDrunk() {
        Vector2 prevMovement = movement;
        if (firstDrink) {
            xScramble = Random.Range(0,2)*2-1; //will either be -1 or 1
            yScramble = Random.Range(0,2)*2-1;
            firstDrink = false;
            Invoke("SoberUp",10.0f);

        }
        //scramble up their movement
        movement.x = 0.5f*xScramble*prevMovement.y;
        movement.y = 0.5f*yScramble*prevMovement.x;
    }

    void SoberUp() {
        firstDrink = true;
        isDrunk = false;
    }
    // end drunkscript



    // Script when player is on ice

    void IsOnIce() {
        if (landedOnIce == false) {
            movement = GameObject.Find("Utils").GetComponent<Utilities>().GetMainDirection(lastMovement);
            //StartCoroutine(IsLandedFrames(transform.position, 5));
            StartCoroutine(IsLandedTime(transform.position, 0.1f));
        } else {
            if (movement != Vector2.zero) {
                landedOnIce = false;
            }
        }
    }

    IEnumerator IsLandedFrames(Vector2 initialIcePosition, int waitFrames) {
        for (int i=0; i < waitFrames; i++){
            yield return null;
        }
        if ((Vector2) transform.position == initialIcePosition) {
            landedOnIce = true;
        }
    }

    IEnumerator IsLandedTime(Vector2 initialIcePosition, float waitTime) {
        yield return new WaitForSeconds(waitTime);
        if ((Vector2) transform.position == initialIcePosition) {
            landedOnIce = true;
        }
    }

    // end icescript


    void ManipulateAnimator() {

        Vector3 direction = GameObject.Find("Utils").GetComponent<Utilities>().GetMainDirection(movement);



        if (direction == transform.up) {
            animator.SetInteger("direction", 1);
            animator.speed = 1.0f;
        }

        if (direction == -transform.up) {
            if (isOnLadder == false) {
                animator.SetInteger("direction", 2);
                animator.speed = 1.0f;
            }
        
        }

        if (direction == transform.right) {
            if (isOnLadder == false) {
                animator.SetInteger("direction", 0);
                GetComponent<SpriteRenderer>().flipX = false;
                animator.speed = 1.0f;
            }
        
        }

        if (direction == -transform.right) {
            if (isOnLadder == false) {
                animator.SetInteger("direction", 0);
                GetComponent<SpriteRenderer>().flipX = true;
                animator.speed = 1.0f;
            }

            
        }

        if (direction == Vector3.zero) {
            if (animator.GetInteger("direction") == 0) {
                animator.SetInteger("direction", -1);
            }
            else {
                animator.speed = 0.0f;
            }
           
        }

        
        if (isOnIce) {
            animator.speed = 0.0f;
        }

    }


    //public function to turn player around
    public void TurnPlayerToward(Vector3 direction, float waitTime = 0.0f) {
        //direction should be transform.up, right or -up or -right.
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




    public void CanBeDetectedAgain() {
        detected = false;
    }


    //// FOR DEBUGGING PURPOSES ////
    void DebugPressed() {
    //Do whatever here that you want to test is space is pressed. For Debugging purposes.
        Debug.Log("Debug pressed");
        //ToggleColliders();
        //TurnPlayerToward(transform.right,0.1f);

        //chapter3Progress.StartEpilog();



    }

    void ToggleColliders() {
        if (GetComponent<BoxCollider2D>().enabled) {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
        } else {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }
}
