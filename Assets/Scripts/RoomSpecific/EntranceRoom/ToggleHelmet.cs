using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHelmet : MonoBehaviour
{
    public SpriteRenderer sr;

    void Awake() {
        sr.enabled = false;
    }

    public void PutHelmetOn() {
        sr.enabled = true;
    }

    public void PutHelmetOff() {
        sr.enabled = false;
    }
}
