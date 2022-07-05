using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalColorManager : MonoBehaviour
{
    public GameObject product;
    public List<Color> availableColors;

    void Start()
    {
        availableColors.Add(Color.blue);
        availableColors.Add(Color.green);
        availableColors.Add(Color.red);
    }

    public void ChangeToNextColor()
    {
       product.GetComponent<Renderer>().material.color = Color.green;
       product.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
    }
}
