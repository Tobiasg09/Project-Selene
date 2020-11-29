using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio; //for a bunch of audio stuff
using System; //for the Find method. Super useful


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Sound[] backgroundMusics;


    private string currentlyPlayingBackgroundMusic = "none";
    private bool overwriteMusic = false;
    private bool canChangeBackgroundMusic = true;
    private bool canPlayBackgroundMusic = true;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in backgroundMusics) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) {
        //only for soundEffects
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name) {
        //only for soundEffects
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }



    public void PlayBackgroundMusic(string name, bool isOverwrite = false, float waitTime = 0.5f) {
        //this will play the background music associated with the name IF: it is not currently playing that one and that there is no overwrite music. You can toggle whether to use overwrite music. But that will play until you call StopOverwriteMusic. Will also always wait some seconds before changing to new song


        if (canPlayBackgroundMusic) {
            if (name != currentlyPlayingBackgroundMusic && overwriteMusic == false && canChangeBackgroundMusic) { //only play if there is no overwrite music playing and if it is not the same as the one already currently playing
                canChangeBackgroundMusic = false;
                StartCoroutine(CanChangeBackgroundMusicAgain());
                StartCoroutine(PlayBackgroundMusicHelper(name, waitTime));
                StopBackgroundMusic();
            }

            if (name != currentlyPlayingBackgroundMusic && isOverwrite) { //if it is overwrite, just play regardless.
                overwriteMusic = true;
                canChangeBackgroundMusic = false;
                StartCoroutine(CanChangeBackgroundMusicAgain());
                StartCoroutine(PlayBackgroundMusicHelper(name, waitTime));
                StopBackgroundMusic();
            }
        }


        
    }

    public IEnumerator CanChangeBackgroundMusicAgain() {
        yield return new WaitForSeconds(5.0f);
        canChangeBackgroundMusic = true;
    }


    public IEnumerator PlayBackgroundMusicHelper(string name, float waitTime) {
        yield return new WaitForSeconds(waitTime);
        currentlyPlayingBackgroundMusic = name;
        Sound s = Array.Find(backgroundMusics, backgroundMusic => backgroundMusic.name == name);
        Debug.Log(name);
        s.source.Play();

    }


    public void StopOverwriteMusic() {
        overwriteMusic = false;
        StopBackgroundMusic();
    }

    public void ToggleCanPlayBackgroundMusic(bool temp) {
        if (temp) {
            canPlayBackgroundMusic = true;
        } else {
            StopBackgroundMusic();
            canPlayBackgroundMusic = false;
        }
    }


    public void StopBackgroundMusic() {
        foreach(Sound s in backgroundMusics) {
            s.source.Stop();
        }
    }


}
