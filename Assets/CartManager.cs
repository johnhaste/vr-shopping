using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartManager : MonoBehaviour
{

    //Total Price
    public float totalPrice;
    public TextMeshProUGUI totalPriceText;

    public static CartManager instance;
 
    //Singleton
    private void Awake(){
        if(instance != null && instance != this){
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
        updatePrice();
    }

    public void addProductToCart(GameObject currentProduct)
    {
        totalPrice += currentProduct.GetComponent<Product>().price;
        updatePrice();
    }

    public void removeProductFromCart(GameObject currentProduct)
    {
        totalPrice -= currentProduct.GetComponent<Product>().price;
        updatePrice();
    }

    public void updatePrice()
    {
        totalPriceText.text = "Total: U$$"+totalPrice;
    }

}
