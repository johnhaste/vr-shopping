using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Product : MonoBehaviour
{
    //Attributes
    public string name;
    public string descr;
    public float price;
    public singularity productSingularity;
    public state productState;
    public Vector3 originalScale;
    public bool isSmall;

    //Status
    public enum singularity{ORIGINAL, COPY}
    public enum state{SHELF, CART}

    //Grab area
    public GameObject grabArea;

    void Start()
    {
        originalScale = transform.localScale;
        isSmall = false;
    }
   
    void OnTriggerEnter(Collider col)
    {
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
        if(col.name == "Inside Cart" && productState != state.SHELF)
        {
            productState = state.SHELF;
            CartManager.instance.removeProductFromCart(gameObject);
        }
    }

    //Check if the product is in the cart when it's released
    public void CheckIfItsInCart(GameObject insideCart)
    {
        if(productState == state.CART)
        {
            //transform.parent = insideCart.transform;
            CartManager.instance.addProductToSlot(gameObject);
        }
        else
        {
            //transform.parent = null;
            GetComponent<Product>().grabArea.GetComponent<BoxCollider>().enabled = true;
            CartManager.instance.removeProductFromSlot(gameObject);
        }
    }
}
