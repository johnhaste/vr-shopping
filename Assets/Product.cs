using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Product : MonoBehaviour
{
    public enum singularity{
        ORIGINAL, COPY
    }

    public enum state{
        SHELF, CART
    }

    public float price;
    public singularity productSingularity;
    public state productState;

    //Grab area
    public GameObject grabArea;
   
    void OnTriggerEnter(Collider col)
    {
        if(col.name == "Inside Cart")
        {
            productState = state.CART;
            CartManager.instance.addProductToCart(gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.name == "Inside Cart")
        {
            productState = state.SHELF;
            CartManager.instance.removeProductFromCart(gameObject);
        }
    }

    public void CheckIfItsInCart(GameObject insideCart)
    {
        if(productState == state.CART)
        {
            transform.parent = insideCart.transform;
        }
        else
        {
             transform.parent = null;
        }
    }
}
