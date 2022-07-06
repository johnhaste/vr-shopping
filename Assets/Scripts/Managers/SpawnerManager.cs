using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

   public AudioClip soundEffect;
   public GameObject colorChangerLightsaber;

   public void SpawnObjectDuplicate(GameObject currentObject)
   {
    
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
