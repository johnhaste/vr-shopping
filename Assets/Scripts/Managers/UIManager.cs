using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    /*Manages the cart and checkout UI*/

    //Checkout
    public TextMeshProUGUI listOfProducts;
    public TextMeshProUGUI totalPriceCheckoutText;

    //Cart
    public TextMeshProUGUI totalPriceCartText;

    //Singleton
    public static UIManager instance;
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

    void Start()
    {
        listOfProducts.text = "Your cart is currently empty!";
    }

    //Updates the price using USD format
    public void UpdatePrice(float totalPrice)
    {
        totalPriceCartText.text = "Total: U$$" + totalPrice.ToString("F2");;;
        totalPriceCheckoutText.text  = "Total: U$$" + totalPrice.ToString("F2");;;
    }

    //Update the list of products with their names and prices
    public void UpdateListOfProducts(List<GameObject> productsInCart)
    {
        string completeText = "";

        //Adds the text of each product in the list
        foreach(GameObject product in productsInCart)
        {
            Product productInfo = product.GetComponent<Product>();
            completeText += productInfo.name + ":" + productInfo.price + "\n";
        }

        //Updates the text
        listOfProducts.text = completeText;

    }

    public void EmptyListOfProducts()
    {
        listOfProducts.text = "Your cart is currently empty!";
    }
}
