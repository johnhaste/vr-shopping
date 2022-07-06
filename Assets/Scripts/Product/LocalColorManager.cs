using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalColorManager : MonoBehaviour
{
    //The product that will have the color changed
    public GameObject product;

    //The available colors
    public List<Color> availableColors;

    //The current color index
    public int index;

    void Start()
    {
        availableColors.Add(Color.blue);
        availableColors.Add(Color.green);
        availableColors.Add(Color.red);
    }

    //Changes the material to the next color
    public void ChangeToNextColor()
    {

        //Changes the index
        if(index < (availableColors.Count - 1) )
        {
            index++;
        }
        else
        {
            index = 0;
        }

        //Update the color and the emission color
        product.GetComponent<Product>().coloredPart.GetComponent<Renderer>().material.color = availableColors[index];
        product.GetComponent<Product>().coloredPart.GetComponent<Renderer>().material.SetColor("_EmissionColor", availableColors[index]);
    }
}
