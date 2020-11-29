using UnityEngine.Audio; //for a bunch of audio stuff
using UnityEngine;

// class for our sounds

[System.Serializable]
public class Sound
{
    public string name;
     public AudioClip clip;
     [Range(0.0f,1.0f)]
     public float volume=1;
     [Range(0.1f,5.0f)]
     public float pitch=1;
     public bool loop;

     [HideInInspector]
     public AudioSource source;
    
}
