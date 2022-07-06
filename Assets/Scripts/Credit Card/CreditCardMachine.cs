using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditCardMachine : MonoBehaviour
{

    /*Detects when whe credit card is touching the machine, so it
    starts the countdown and confirm the payment.*/

    //UI
    public GameObject NFCLogo;
    public TextMeshProUGUI CreditCardMachineText;
    public Image loadingBarImage;

    //Buy countdown
    private int countdown;

    //Sound when payment is approved
    public AudioClip soundEffect;

    //Starts the countdown routine
    public void StartCountdown()
    {
        countdown = 3;
        StartCoroutine(Countdown());
    }
     
    //Starts the countdown to confirm the payment
    public IEnumerator Countdown()
    {

        DisplayLoadingBarImage();

        while(countdown > 0)
        {
            CreditCardMachineText.text = "Approximate The Card and wait: \n" + countdown;
            countdown--;
            loadingBarImage.rectTransform.sizeDelta = new Vector2(40 - (countdown * 15), 5);
            yield return new WaitForSeconds(1f);
        }
        
        //Feedback for the user
        CreditCardMachineText.text = "Payment Approved!";
        
        //Makes a sound
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);

        //Removes all products from the cart
        //TODO fix removal
        //CartManager.instance.EmptyCart();
    }

    //If the card is removed, stops the operation
    public void StopOperation()
    {
        StopAllCoroutines();
        HideLoadingBarImage();
        CreditCardMachineText.text = "Approximate The Card and WAIT";
    }

    public void DisplayLoadingBarImage()
    {
        loadingBarImage.enabled = true;
    }

    public void HideLoadingBarImage()
    {
        loadingBarImage.enabled = false;
    }
}
