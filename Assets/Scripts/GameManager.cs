using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool startPlaying = true;
    //public beat_scroller beatScroller; //this controls the beat scroller. we want to access it, so we create a ref point for it

    public static GameManager instance; //instance of game manager *all notes* refer to.

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NoteHit(){
        Debug.Log("hit on time");
    }

    public void NoteMissed(){
        Debug.Log("missed note");
    }
}
