using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCard : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        print("Col:" + col.name);

        if(col.name == "Credit Card Machine")
        {
            //col.GetComponent<CreditCardMachine>().CreditCardMachineText.text = "3";
            col.GetComponent<CreditCardMachine>().StartCountdown();

        }
    }

    void OnTriggerExit(Collider col)
    {
        print("Col:" + col.name);

        if(col.name == "Credit Card Machine")
        {
            
            col.GetComponent<CreditCardMachine>().StopOperation();
        }
    }
}
