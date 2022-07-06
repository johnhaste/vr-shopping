using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCard : MonoBehaviour
{
    /*Detects when whe credit card is touching the machine, so it
    starts the countdown and confirm the payment.*/

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "Credit Card Machine")
        {
            col.GetComponent<CreditCardMachine>().StartCountdown();

        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.name == "Credit Card Machine")
        {
            col.GetComponent<CreditCardMachine>().StopOperation();
        }
    }
}
