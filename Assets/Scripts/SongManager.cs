using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Replaces beat_scroller

public class SongManager : MonoBehaviour
{

    //Song information and position for synced actions.
    public AudioSource musicSource;
    public float songBPM;           //beats per minute
    public float beginOffset = 0f;   //silence/song interlude, before gameplay begins.
    public int beatsShownInAdvance = 25; /**TODO: max number of beats you can show on screen at once? for sick beat drops*/

    public float[,] notes; //*TODO initialize as a LIST not an array*/
    public NoteObject sampleNote;
    private int nextIndex;

    public float secPerBeat; //seconds per beat
    //private?
    public float songPosition;      //song position in seconds
    public float songPositionInBeats; //song position in beats
    public float dspSongTime; //displacement - how many  seconds have passed since song started

    //index of the next note to be spawned, tranversing the array of notes.
    //++ whenever a note is spawned.

    private float topY = 1f;
    private float botY = -2f;
    public float spawnX = 10f;
    public float leaveX = -10f;

    public KeyCode topKey;
    public KeyCode botKey;

    public static SongManager song;


    // Start is called before the first frame update
    void Start()
    {
        song = this;
        //Load audiosource for this SongManager GameObject.
        //musicSource = GetComponent<AudioSource>();

        //Calculate the # of seconds per beat.
        secPerBeat = 60f / songBPM;

        //Mark when the song starts. 
        dspSongTime = (float) AudioSettings.dspTime;

        //TODO: initialize as a LIST not an array.
        notes = new float[13,2]{
            {1f, 1f},
            {2f, 2f},
            {-3f, 3f},
            {4f, -4f},
            {-5f, -5f},
            {10f, -1f},
            {10.1f, -1f},
            {10.2f, -1f},
            {10.3f, -1f},
            {10.4f, -1f},
            {10.8f, -1f},
            {-1f, 11f},
            {-1f, 15f}
        };

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

        /**Initialize the music notes.
            1) if there are notes left, and 2) the note's beat is < the song position + # to show,
            create the music note and initialize its position. 
            if a noteBeat is < 0, then one side doesn't exist (maybe try implementing a different way?)
        */
        
        if(nextIndex < notes.GetLength(0) && 
            notes[nextIndex, 0] < songPositionInBeats + beatsShownInAdvance &&
            notes[nextIndex, 1] < songPositionInBeats + beatsShownInAdvance){

                if(notes[nextIndex, 0] > 0){
                    Vector3 position = new Vector3(spawnX, topY, 0f);
                    NoteObject note = (NoteObject) Instantiate(sampleNote, position, Quaternion.identity);

                    note.beatOfThisNote = notes[nextIndex, 0];
                    note.keyToPress = topKey;
                    note.spawnPos = new Vector2(spawnX, topY);
                    note.removePos = new Vector2(leaveX, topY);
                }

                if(notes[nextIndex, 1] > 0){
                    Vector3 position = new Vector3(spawnX, botY, 0f);
                    NoteObject note = (NoteObject) Instantiate(sampleNote, position, Quaternion.identity);

                    note.beatOfThisNote = notes[nextIndex, 1];
                    note.keyToPress = botKey;
                    note.spawnPos = new Vector2(spawnX, botY);
                    note.removePos = new Vector2(leaveX, botY);
                }
                nextIndex++;
        }

    }
}
