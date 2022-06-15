using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Replaces beat_scroller

public class SongManager : MonoBehaviour
{

    //Song information and position for synced actions.
   
    public float songPosition;      //song position in seconds
    public float songPositionInBeats; //song position in beats
    public float dspSongTime; //displacement - how many  seconds have passed since song started
    
    public AudioSource musicSource;
    public float songBPM;   //beats per minute
    public float secPerBeat; //seconds per beat
    public float beginOffset = 0; //silence/song interlude, before gameplay begins.
    
    /**TODO: max number of beats you can show on screen at once?
    for those sick beat drops, you need a LOOOOT of notes!~*/
    public int beatsShownInAdvance = 25; 

    //all the positions (in beats) of notes in the song.
    //**TODO: try this as a nested array instead?*/
    public float[] topNotes;
    public float[] botNotes;

    //index of the next note to be spawned, tranversing the array of notes.
    //++ whenever a note is spawned.
    public int topNextIndex = 0;
    public int botNextIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        //Load audiosource for this SongManager GameObject.
        musicSource = GetComponent<AudioSource>();

        //Calculate the # of seconds per beat.
        secPerBeat = 60f / songBPM;

        //Mark when the song starts. 
        dspSongTime = (float) AudioSettings.dspTime;

        /**TODO: remove/change when implementing cutscene.
        until then, play immediately upon starting scene.*/
        musicSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        //Determine elapsed TIME since song started.
        songPosition = (float) (AudioSettings.dspTime - dspSongTime - beginOffset);

        //Determine elapsed BEATS since song started
        songPositionInBeats = songPosition / secPerBeat;


        //Initialize the next music notes
        if(botNextIndex < botNotes.Length && botNotes[botNextIndex] < songPositionInBeats + beatsShownInAdvance){
            //initialize music note prefab

            //initialize music note fields 

            botNextIndex++;
        }

        if(topNextIndex < topNotes.Length && topNotes[topNextIndex] < songPositionInBeats + beatsShownInAdvance){
            //initialize music note prefab

            //initialize music note fields 

            topNextIndex++;
        }


        /*note: the MUSIC NOTES update() control their movement, not the songmanager.*/

    }
}
