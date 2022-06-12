using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat_scroller : MonoBehaviour
{
    // Start is called before the first frame update

    public float beatTempo; //how fast arrows fall down
    public bool hasStarted;

    void Start()
    {
        beatTempo = beatTempo / 60f; //how fast this moves per second. 120 bpm / 60 = 2 beats per second 
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){
            /*
            if(Input.anyKeyDown){
                hasStarted = true;
            }
            */
        } else {
            transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);
        }
    }
}
