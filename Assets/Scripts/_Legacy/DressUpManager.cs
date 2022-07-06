using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressUpManager : MonoBehaviour
{

    public GameObject playerHead;
    public GameObject playerHelmet;

    //Singleton
    public static DressUpManager instance;
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

    public void ActivateHelmet()
    {
        playerHelmet.SetActive(true);
    }

    public void DeactivateHelmet()
    {
        playerHelmet.SetActive(false);
    }
}
