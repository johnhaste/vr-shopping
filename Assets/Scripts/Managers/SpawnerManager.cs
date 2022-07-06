using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
   //Makes a sound when it spawns an object
   public AudioClip soundEffect;

   //Manages the color Changer for the lightsaber
   public GameObject colorChangerLightsaber;

   //Singleton
   public static SpawnerManager instance;
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

   //Creates a copy of the product
   public void SpawnObjectDuplicate(GameObject currentObject)
   {

        //Checks if it must duplicate the product
        if(currentObject.GetComponent<Product>().productSingularity == Product.singularity.ORIGINAL)
        {
            
            //Instantiate a new original object where it was taken
            GameObject newObject = Instantiate(currentObject, currentObject.transform.position, Quaternion.identity);
            newObject.GetComponent<Product>().productSingularity = Product.singularity.ORIGINAL;
            AudioSource.PlayClipAtPoint(soundEffect, transform.position);

            //Updates the color changer
            if(currentObject.name.Contains("Lightsaber"))
            {
                print("Update object");
                colorChangerLightsaber.GetComponent<LocalColorManager>().product = newObject;
            }

            //Make the current object in my hand become a copy
            currentObject.GetComponent<Product>().productSingularity = Product.singularity.COPY;
            currentObject.GetComponent<Product>().grabArea.GetComponent<BoxCollider>().enabled = false;
            currentObject.GetComponent<TurnAround>().enabled = false;

        }
        
   }
}
