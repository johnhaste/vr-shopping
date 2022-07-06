using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{

   public static PhysicsManager instance;
 
    //Singleton
    private void Awake(){
        if(instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }


   public void MakeObjectPhysical(GameObject currentObject)
   {
        print("Is Grabbing:" + gameObject.name);

        currentObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        currentObject.GetComponent<Rigidbody>().isKinematic = false;
        currentObject.GetComponent<Rigidbody>().useGravity = true;
        currentObject.GetComponent<TurnAround>().enabled = false;
   }

}
