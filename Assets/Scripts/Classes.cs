using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creating our own class

[System.Serializable] //If making own class, need to add this to add to inspector
public class Dialog
{   
    [TextArea(3,10)]
    public string[] sentences;
}



[System.Serializable]
public class Patrol
{   
    //if isLoop is true, patrol is a loop. All intermediate patrolpoints will be called before finding a new patrol
    public bool isLoop;
    public PatrolPoint[] patrolPoints;
}



[System.Serializable]
public class PatrolPoint {
    public Transform coordinates;
    public float waitTime;
}