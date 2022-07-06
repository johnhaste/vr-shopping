using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSensor : MonoBehaviour
{
    //Object that plays the sound
    public GameObject audioSourceObject;

    void OnTriggerEnter(Collider col)
    {
        //If it's close to the player
        if(col.name.Contains("XR"))
        {
            //Raises the volume
            audioSourceObject.GetComponent<AudioSource>().volume = 0.3f;
        }
    }

     void OnTriggerExit(Collider col)
    {
        //If it's far to the player
        if(col.name.Contains("XR"))
        {
           //Reduces the volume
           audioSourceObject.GetComponent<AudioSource>().volume = 0.0f;
        }
    }
}
