using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

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

    public void UpdatePrice(float totalPrice)
    {
        totalPriceCartText.text = "Total: U$$" + totalPrice.ToString("F2");;;
        totalPriceCheckoutText.text  = "Total: U$$" + totalPrice.ToString("F2");;;
    }

    public void UpdateListOfProducts(List<GameObject> productsInCart)
    {
        string completeText = "";

        foreach(GameObject product in productsInCart)
        {
            Product productInfo = product.GetComponent<Product>();

            completeText += productInfo.name + ":" + productInfo.price + "\n";
        }

        listOfProducts.text = completeText;

    }
}
