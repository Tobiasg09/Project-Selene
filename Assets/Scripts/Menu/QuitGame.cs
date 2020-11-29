using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ExitGame();
        }
    }

    public void ExitGame() {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
