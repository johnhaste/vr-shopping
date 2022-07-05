using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditCardMachine : MonoBehaviour
{

    //UI
    public GameObject NFCLogo;
    public TextMeshProUGUI CreditCardMachineText;
    public Image loadingBarImage;

    private int countdown;

    public void StartCountdown()
    {
        countdown = 3;
        StartCoroutine(Countdown());
    }

    public void DisplayLoadingBarImage()
    {
        loadingBarImage.enabled = true;
    }

    public void HideLoadingBarImage()
    {
        loadingBarImage.enabled = false;
    }

    public void StopOperation()
    {
        StopAllCoroutines();
        HideLoadingBarImage();
        CreditCardMachineText.text = "Approximate The Card and WAIT";
    }

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
        
        CreditCardMachineText.text = "Payment Approved!";
        CartManager.instance.EmptyCart();
    }
}
