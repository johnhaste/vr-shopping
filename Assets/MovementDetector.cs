using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour
{

    //First you define the AudioClip
    public AudioClip soundEffect;
    public Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckIfMoved());
    }

    private IEnumerator CheckIfMoved()
    {
        while (true)
        {
           float movementDifferenceY =  Mathf.Abs(lastPosition.y - transform.position.y);
           //float movementDifferenceX =  Mathf.Abs(lastPosition.x - transform.position.x);
           //float movementDifferenceZ =  Mathf.Abs(lastPosition.z - transform.position.z);
           if(movementDifferenceY > 0.2f ){
               //Plays the sound at that position
               AudioSource.PlayClipAtPoint (soundEffect, transform.position);
           }
           lastPosition = transform.position;
           yield return new WaitForSeconds(0.3f);
        }
    }
}
