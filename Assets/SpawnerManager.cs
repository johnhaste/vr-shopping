using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
   public void SpawnObjectDuplicate(GameObject currentObject)
   {
        if(currentObject.GetComponent<Product>().productState == Product.state.ORIGINAL)
        {
            
            //Instantiate a new original object where it was taken
            GameObject newObject = Instantiate(currentObject, currentObject.transform.position, Quaternion.identity);
            newObject.GetComponent<Product>().productState = Product.state.ORIGINAL;

            //Make the current object become a copy
            currentObject.GetComponent<Product>().productState = Product.state.COPY;
            currentObject.GetComponent<TurnAround>().enabled = false;

        }
        
   }
}
