using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSensor : MonoBehaviour
{

    public AudioSource audioSource;

    void OnTriggerEnter(Collider col)
    {
        if(col.name.Contains("XR"))
        {
           audioSource.volume = 0.3f;
        }
    }

     void OnTriggerExit(Collider col)
    {
        if(col.name.Contains("XR"))
        {
           audioSource.volume = 0.0f;
        }
    }
}
