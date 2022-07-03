using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    public float rotationsPerMinute = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1.0f*rotationsPerMinute*Time.deltaTime, 0);
    }
}
