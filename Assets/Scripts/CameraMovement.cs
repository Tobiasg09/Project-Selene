using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //IDEAS TO IMPROVE CAMERA: - use cinemachine
    // - make a dead zone in the middle
    // - add boundaries (https://www.youtube.com/watch?v=OWJa6lcFTXk and part V)

    public Transform target;
    public float smoothing;

    void Awake() {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = targetPosition;
    }
    

    void FixedUpdate()
    {
        
        if (transform.position != target.position) {
            //Lerp is a special function, wich stands for linear interpolation. 
            //finds distance betzeen two points and moves a fraction of that distance
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); //to fix the z;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing); //curr position, desired position, amount to cover 
        }
    }


    public void MoveInstantly() {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = targetPosition;
    }
}
