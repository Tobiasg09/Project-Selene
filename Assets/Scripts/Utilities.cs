using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //for image manipulation
using UnityEngine.SceneManagement; //for scene manipulation
using TMPro; //for TMPro

public class Utilities : MonoBehaviour
{
    public GameObject blackScreen;
    public TextAsset exitGameDialog;

    private DialogManager dialogManager;

    //a place to write a bunch of general-use methods that can be used by a variety of objects

    public Vector2 FromWhichDirection(Vector2 self, Vector2 pointOfInterest) {
        //Will calculate from where something came, but in either 'up', 'down', 'left' or 'right'.
        //Can be used e.g. to rotate NPCs depending on from where you talked to them

        Vector2 connector = pointOfInterest - self; //maybe name this better. But it points from self to point of interest (check vector calculus)

        if (Mathf.Abs(connector.x) >= Mathf.Abs(connector.y)) { //moving horizontally more than vertically
            
            if (connector.x > 0) { //moving right
                return transform.right;
            } else if (connector.x < 0) { //moving left
                return -transform.right;
            } else {
                return Vector3.zero;
            }

        } else { //moving vertically

            if (connector.y < 0) { //moving up
                return -transform.up;
            } else if (connector.y > 0) { //moving down
                return transform.up;
            } else {
               return Vector3.zero;
            }

        }
    }



    public Vector2 GetMainDirection(Vector2 connector) {
        //Will calculate from where something came, but in either 'up', 'down', 'left' or 'right'.
        //Can be used e.g. to rotate NPCs depending on from where you talked to them

        if (Mathf.Abs(connector.x) >= Mathf.Abs(connector.y)) { //moving horizontally more than vertically
            
            if (connector.x > 0) { //moving right
                return transform.right;
            } else if (connector.x < 0) { //moving left
                return -transform.right;
            } else {
                return Vector3.zero;
            }

        } else { //moving vertically

            if (connector.y < 0) { //moving up
                return -transform.up;
            } else if (connector.y > 0) { //moving down
                return transform.up;
            } else {
               return Vector3.zero;
            }

        }
    }



/// Create a fade out fade in script

    public void FadeOutFadeIn(float speed, int stepsizeOut, int stepsizeIn, float waitBetween) {
        StartCoroutine(FadeOutFadeInHelper(speed, stepsizeOut, stepsizeIn, waitBetween));

    }

    public IEnumerator FadeOutFadeInHelper(float speed, int stepsizeOut, int stepsizeIn, float waitBetween) {
        int alpha=0;
        blackScreen.SetActive(true);
        Image image = blackScreen.GetComponent<Image>();
        image.color = new Color32(0,0,0,(byte)alpha);
        

        while (alpha != 255) {
            alpha += stepsizeOut;
            if (alpha > 255) {
                alpha = 255;
            }
            image.color = new Color32(0,0,0,(byte)alpha);
            yield return new WaitForSeconds(speed);
        }

        yield return new WaitForSeconds(waitBetween);

        while (alpha != 0) {
            alpha -= stepsizeIn;
            if (alpha < 0) {
                alpha = 0;
            }
            image.color = new Color32(0,0,0,(byte)alpha);
            yield return new WaitForSeconds(speed);
        }


        blackScreen.SetActive(false);
    }





    //create a respawn script

    public void RespawnPlayer(Transform respawnPosition, bool useFade = true) {
        float respawnDelay = 0.0f;
        if (useFade) {
            FadeOutFadeIn(0.01f,20,10,1);
            respawnDelay = 1.0f;
        }
        StartCoroutine(RespawnHelper(respawnPosition, respawnDelay));

    }

    public IEnumerator RespawnHelper(Transform respawnPosition, float waitTime) {
        yield return new WaitForSeconds(waitTime);

        GameObject.Find("Player").GetComponent<Transform>().position = respawnPosition.position;
        GameObject.Find("Main Camera").GetComponent<CameraMovement>().MoveInstantly();
    }


    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            
            bool playerCanInteract = GameObject.Find("Player").GetComponent<PlayerAction>().canInteract;
            if (playerCanInteract) {
                dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
                dialogManager.Talk(exitGameDialog, StartDialog, EndDialogEndGame);
            }
            

        }
    }

    void EndDialogEndGame() {
        bool stopGame = (int) dialogManager.story.variablesState["ExitGame"] == 1 ? true : false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
        if (stopGame) {
            SceneManager.LoadScene(0);
        }
    }



    //Vector2 to angle (deg) and back
    public float Vector2Angle(Vector2 vector) {
        //will return between -179 and 180
        if (vector.y >= 0) {
            return Vector2.Angle(vector, new Vector2(1,0));
        } else {
            return Vector2.Angle(vector, new Vector2(1,0)) * -1;
        }
    }

    //Angle (deg) to Vector2
    public Vector2 Angle2Vector(float angle) {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    }



    public void Test(){
        Debug.Log("Player Detected.");
    }



    public void StartDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(false);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(false);
    }

    public void EndDialog() {
        GameObject.Find("Player").GetComponent<PlayerMovement>().ToggleCanMove(true);
        GameObject.Find("Player").GetComponent<PlayerAction>().ToggleCanInteract(true);
    }


}
