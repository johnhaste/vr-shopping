using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSensor : MonoBehaviour
{

    public GameObject audioSourceObject;

    void OnTriggerEnter(Collider col)
    {
        if(col.name.Contains("XR"))
        {
            audioSourceObject.GetComponent<AudioSource>().volume = 0.3f;
        }
    }

     void OnTriggerExit(Collider col)
    {
        if(col.name.Contains("XR"))
        {
           audioSourceObject.GetComponent<AudioSource>().volume = 0.0f;
        }
    }
}
