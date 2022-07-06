using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Product : MonoBehaviour
{
    /* Contains all Product properties and collision detectors*/

    //Attributes
    public string name;
    public string descr;
    public float price;
    public singularity productSingularity;
    public state productState;
    public Vector3 originalScale;
    public bool isSmall;

    //Color
    public GameObject coloredPart;

    //Status
    public enum singularity{ORIGINAL, COPY}
    public enum state{SHELF, CART, HEAD}

    //Grab area
    public GameObject grabArea;

    void Start()
    {
        //Saves the product original scale
        originalScale = transform.localScale;
        isSmall = false;
    }
   
    void OnTriggerEnter(Collider col)
    {
        
        //Checks if the product was placed inside the cart
        if(col.name == "Inside Cart" && productState != state.CART)
        {
            //Updates product state
            productState = state.CART;

            //Adds product to cart
            CartManager.instance.addProductToCart(gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        //Checks if the product was removed from the cart
        if(col.name == "Inside Cart" && productState != state.SHELF)
        {
            productState = state.SHELF;
            CartManager.instance.removeProductFromCart(gameObject);
        }
    }

    //Check if the product is in the cart when it's released
    public void CheckIfItsInCart(GameObject insideCart)
    {
        //If the product was dropped inside the cart
        if(productState == state.CART)
        {
            //Adds the product to an available slot
            CartManager.instance.addProductToSlot(gameObject);
        }
        else
        {
            //Removes the grab area
            GetComponent<Product>().grabArea.GetComponent<BoxCollider>().enabled = true;
            
            //Removes the product from the specific slot
            CartManager.instance.removeProductFromSlot(gameObject);
        }
    }
}
