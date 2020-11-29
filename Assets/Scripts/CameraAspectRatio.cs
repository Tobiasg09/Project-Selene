using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    // Use this for initialization
void Update () 
{

    //NOTE: UI doesn't scale with this as expected! to fix this, in canvas do canvas scaler to scale with screen size, then screen match mode should be expand.
    //also, canvas should be in screen space - camera


    float targetaspect = 4.0f / 3.0f;
    float windowaspect = (float)Screen.width / (float)Screen.height;
    float scaleheight = windowaspect / targetaspect;
    Camera camera = GetComponent<Camera>();

    if (scaleheight < 1.0f)
    {  
        Rect rect = camera.rect;

        rect.width = 1.0f;
        rect.height = scaleheight;
        rect.x = 0;
        rect.y = (1.0f - scaleheight) / 2.0f;
        
        camera.rect = rect;
    }
    else
    {
        float scalewidth = 1.0f / scaleheight;

        Rect rect = camera.rect;

        rect.width = scalewidth;
        rect.height = 1.0f;
        rect.x = (1.0f - scalewidth) / 2.0f;
        rect.y = 0;

        camera.rect = rect;
    }
}
}
