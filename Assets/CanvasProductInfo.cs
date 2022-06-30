using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasProductInfo : MonoBehaviour
{
    public Product productInfo;

    public TextMeshProUGUI productNameText;
    public TextMeshProUGUI productDescrText;
    public TextMeshProUGUI productPriceText;

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
