using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendPatrol : MonoBehaviour
{
    public Patrol[] patrol;

    
    public void Patrol() {
        Patroller patroller = GetComponent<Patroller>(); //should be on same gameobject
        patroller.StartPatrol(patrol[0]);
    }
}
