using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartManager : MonoBehaviour
{

    //Total Price
    public float totalPrice;

    //Products List
    public List<GameObject> productsInCart;
    public List<GameObject> SlotsInCart;

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

    public void addProductToSlot(GameObject currentProduct)
    {

        //Selects the appropriate slot
        GameObject currentSlot = SlotsInCart[productsInCart.Count - 1];

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
        
    }

    public void removeProductFromSlot(GameObject currentProduct)
    {
        currentProduct.transform.parent = null;
    }

    public void addProductToCart(GameObject currentProduct)
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
    }

}
