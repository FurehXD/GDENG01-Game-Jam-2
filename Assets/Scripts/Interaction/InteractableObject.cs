using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
   public void Interact()
    {
        Debug.Log(this.gameObject.name + " has been interacted");
    }
}
