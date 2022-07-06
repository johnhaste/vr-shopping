using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasProductInfo : MonoBehaviour
{
    //Drag the current product to this
    public Product productInfo;

    //The information GUI of the product
    public TextMeshProUGUI productNameText;
    public TextMeshProUGUI productDescrText;
    public TextMeshProUGUI productPriceText;

    //If the Product editor changes, updates the canvas of the product information
    void OnValidate()
    {
        if(productInfo != null)
        {
            productNameText.text  = productInfo.name;
            productDescrText.text = productInfo.descr;
            productPriceText.text = "U$$"+productInfo.price.ToString("F2");;
        }   
    }
}
