using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject MainPanel;
    public GameObject AboutPanel;

    void Start() {
        FindObjectOfType<AudioManager>().Play("Title");
    }


    public void ClickAbout(){
        MainPanel.SetActive(false);
        AboutPanel.SetActive(true);
    }

    public void ClickBack(){
        MainPanel.SetActive(true);
        AboutPanel.SetActive(false);
    }
}
