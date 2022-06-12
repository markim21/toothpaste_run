using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Check if the correct note is pressed, and pressed on time.

public class NoteObject : MonoBehaviour
{
    public bool canBePressed; 

    public KeyCode keyToPress;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){
                gameObject.SetActive(false);

                GameManager.instance.NoteHit(); //tell game manager, hey we hit a note! 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.tag == "Activator"){
            canBePressed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other){

        if(other.tag == "Activator"){
            canBePressed = false;

            GameManager.instance.NoteMissed(); //tell game manager, hey, we missed this note.
        }

    }

}
