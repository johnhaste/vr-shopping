using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalColorManager : MonoBehaviour
{
    public GameObject product;
    public List<Color> availableColors;
    public int index;

    void Start()
    {
        availableColors.Add(Color.blue);
        availableColors.Add(Color.green);
        availableColors.Add(Color.red);
    }

    public void ChangeToNextColor()
    {
        print("Change Color");

        if(index < (availableColors.Count - 1) )
        {
            index++;
        }
        else
        {
            index = 0;
        }

        product.GetComponent<Product>().coloredPart.GetComponent<Renderer>().material.color = availableColors[index];
        product.GetComponent<Product>().coloredPart.GetComponent<Renderer>().material.SetColor("_EmissionColor", availableColors[index]);
    }
}
