using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //for scene manipulation

public class NewGameButton : MonoBehaviour
{

    public void NewGame() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
