using UnityEngine;
using System.Collections.Generic;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light flashlight; 
    public float detectionDuration = 1f; 
    private Dictionary<InteractableObjectGlowing, float> detectedObjects = new Dictionary<InteractableObjectGlowing, float>(); 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }

        // Detect interactable objects if the flashlight is on
        if (flashlight.enabled)
        {
            DetectInteractableObjects();
        }
    }

    private void DetectInteractableObjects()
    {
        RaycastHit hit;

       
        if (flashlight.enabled)
        {
            
            if (Physics.Raycast(flashlight.transform.position, flashlight.transform.forward, out hit))
            {
               
                InteractableObjectGlowing interactable = hit.collider.GetComponent<InteractableObjectGlowing>();

                if (interactable != null)
                {
                   
                    if (!detectedObjects.ContainsKey(interactable))
                    {
                        detectedObjects[interactable] = 0f; // Initialize timer for the new object
                    }

                    detectedObjects[interactable] += Time.deltaTime; // Increment timer

                    
                    if (detectedObjects[interactable] >= detectionDuration)
                    {
                        interactable.StartGlowing();
                    }
                }
            }
        }

        
        List<InteractableObjectGlowing> toRemove = new List<InteractableObjectGlowing>();

        foreach (var entry in detectedObjects)
        {
            
            if (!Physics.Raycast(flashlight.transform.position, flashlight.transform.forward, out hit) || hit.collider.GetComponent<InteractableObjectGlowing>() != entry.Key)
            {
                toRemove.Add(entry.Key);
            }
        }

        
        foreach (var obj in toRemove)
        {
            detectedObjects.Remove(obj);
        }
    }
}
