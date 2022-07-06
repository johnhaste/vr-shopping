using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour
{
    //Tracks the object position
    public Vector3 lastPosition;

    //Sound effect when it moves
    public AudioClip soundEffect;
    
    void Start()
    {
        StartCoroutine(CheckIfMoved());
    }

    private IEnumerator CheckIfMoved()
    {
        while (true)
        {
           float movementDifferenceY =  Mathf.Abs(lastPosition.y - transform.position.y);

           //If the lighsaber moves more than 0.2f in Y in less than 0.3 seconds
           if(movementDifferenceY > 0.2f )
           {
               //Plays the sound at that position
               AudioSource.PlayClipAtPoint (soundEffect, transform.position);
           }

           //Updates the last position every 0.3 seconds
           lastPosition = transform.position;

           //Waits for 0.3 seconds
           yield return new WaitForSeconds(0.3f);
        }
    }
}
