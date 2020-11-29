using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //for scene manipulation

public class ContinueButton : MonoBehaviour
{

    public void Continue() {
        SceneManager.LoadScene(1);
    }
}
