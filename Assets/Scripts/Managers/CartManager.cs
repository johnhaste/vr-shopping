using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartManager : MonoBehaviour
{
    /*Manages the products insert in the cart and the slots where they must be.
    Updates the total price and the slots price of products*/

    //Total Price
    public float totalPrice;

    //Products List
    public List<GameObject> productsInCart;
    public List<GameObject> slotsInCart;

    //Sound when add or remove product
    public AudioClip soundEffect;

    //Singleton
    public static CartManager instance;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        totalPrice = 0;
        UIManager.instance.UpdatePrice(0);
    }

    //Removes all products and empty the cart
    public void EmptyCart()
    {
        foreach(GameObject product in productsInCart)
        {
            removeProductFromCart(product);
            removeProductFromSlot(product);
            Destroy(product.gameObject);
        }
    }

    //Add a miniature product to a specific empty slot
    public void addProductToSlot(GameObject currentProduct)
    {
        //Makes a sound
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);

        //Selects the appropriate slot
        bool hasFoundEmptySlot = false;
        GameObject currentSlot = slotsInCart[0];
        foreach(GameObject cartSlot in slotsInCart)
        {
            if(cartSlot.transform.childCount == 1 && !hasFoundEmptySlot)
            {
                currentSlot = cartSlot;
                hasFoundEmptySlot = true;                
            }
        }

        //Update the price tag
        currentSlot.GetComponent<CartSlot>().productPriceCartText.text = "U$$" + currentProduct.GetComponent<Product>().price;

        //Make the product stay at the same position and rotation of the slot
        currentProduct.transform.position = currentSlot.transform.position;
        currentProduct.transform.rotation = Quaternion.Euler(0f,0f,0f);

        //Insert the product in the slot
        currentProduct.transform.parent = currentSlot.transform;

        //Makes it possible to grab and remove the product later 
        currentProduct.GetComponent<Product>().grabArea.GetComponent<BoxCollider>().enabled = true;

        //Makes the product small
        if(!currentProduct.GetComponent<Product>().isSmall)
        {
            currentProduct.transform.localScale = new Vector3(1f,1f,1f);
            currentProduct.GetComponent<Product>().isSmall = true;
        }

        //Double Check Slots
        UpdateSlotsStatus();
        
    }

    //Removes a product from the slot it was and updates the price tag
    public void removeProductFromSlot(GameObject currentProduct)
    {

        //Makes a sound
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        
        //Resets the price tag
        currentProduct.GetComponentInParent<CartSlot>().productPriceCartText.text = "-";

        //Removes the product from the slot
        currentProduct.transform.parent = null;

        //Double Check Slots
        UpdateSlotsStatus();
    }

    //Extra verification of empty slots
    public void UpdateSlotsStatus()
    {
        foreach(GameObject cartSlot in slotsInCart)
        {
            if(cartSlot.transform.childCount == 1)
            {
                cartSlot.GetComponentInParent<CartSlot>().productPriceCartText.text = "-";           
            }
        }
    }

    //Simulates adding a product to the cart
    public void addProductToCart(GameObject currentProduct)
    {

        //Double check if the product is already in the cart or not
        bool isInCart = false;
        foreach(GameObject product in productsInCart)
        {
            if(product == currentProduct)
            {
                isInCart = true;
            }
        }

        if(!isInCart)
        {
            //Add product to cart
            productsInCart.Add(currentProduct);

            //Adds the current product price
            totalPrice += currentProduct.GetComponent<Product>().price;

            //Update total price UIs
            UIManager.instance.UpdatePrice(totalPrice);

            //Update the checkout text
            UIManager.instance.UpdateListOfProducts(productsInCart);
        }

        //Double Check Slots
        UpdateSlotsStatus();

    }

    //Simulates removing a product from the cart
    public void removeProductFromCart(GameObject currentProduct)
    {
        //Remove product from cart
        productsInCart.Remove(currentProduct);

        //Resets Scale
        if(currentProduct.GetComponent<Product>().isSmall)
        {
            currentProduct.transform.localScale = currentProduct.GetComponent<Product>().originalScale;
            currentProduct.GetComponent<Product>().isSmall = false;
        }

        //Decreases the current product price
        totalPrice -= currentProduct.GetComponent<Product>().price;

        //Update total price UIs
        UIManager.instance.UpdatePrice(totalPrice);

        //Update the checkout text
        UIManager.instance.UpdateListOfProducts(productsInCart);

        //Double Check Slots
        UpdateSlotsStatus();
    }

}
