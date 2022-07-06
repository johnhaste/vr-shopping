using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableGrabbingAndPhysicsWhenCollided : MonoBehaviour
{

    public UIInteractionControllerSwitcher UIInteractionControllerSwitcherLeftHand;
    public UIInteractionControllerSwitcher UIInteractionControllerSwitcherRighttHand;
    public TMP_Text debugText;

    void OnTriggerEnter(Collider col)
    {
        print("Entered:"+col.name);

        if(col.name == "LeftHand UI Controller")
        {
            UIInteractionControllerSwitcherLeftHand.EnableGrab();
        }
        else if(col.name == "RightHand UI Controller")
        {
            UIInteractionControllerSwitcherRighttHand.EnableGrab();
        }
        
        debugText.text = "Enabled Grab";
    }

    void OnTriggerExit(Collider col)
    {
        print("Exited"+col.name);
        
        if(col.name == "LeftHand Base Controller")
        {
            UIInteractionControllerSwitcherLeftHand.DisableGrab();
        }
        else if(col.name == "RightHand Base Controller")
        {
            UIInteractionControllerSwitcherRighttHand.DisableGrab();
        }

        debugText.text = "Disabled Grab";
    }
}
