using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_controller : MonoBehaviour
{

    private SpriteRenderer theSR; //the sprite renderer
    public Sprite defaultImage; //what image looks like normally
    public Sprite pressedImage;

    public KeyCode keyToPress; //the key we want pressed down

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();//the sprite renderer= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            theSR.sprite = pressedImage; //the sprite renderersprite = pressedImage;
        }

        if(Input.GetKeyUp(keyToPress)){
            theSR.sprite = defaultImage; //the sprite renderersprite = defaultImage;
        }
    }
}
