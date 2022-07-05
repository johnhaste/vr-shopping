using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressUpManager : MonoBehaviour
{

    public GameObject playerHead;

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
}
