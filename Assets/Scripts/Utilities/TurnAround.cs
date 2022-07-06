using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    //How fast the object must turn
    public float rotationsPerMinute = 10f;

    void Update()
    {
        transform.Rotate(0, 1.0f*rotationsPerMinute*Time.deltaTime, 0);
    }
}
