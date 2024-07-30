using UnityEngine;
using System.Collections.Generic;

public class InteractableObjectGlowing : MonoBehaviour
{
    private static List<InteractableObjectGlowing> allInteractableObjects = new List<InteractableObjectGlowing>();
    private static int glowingCount = 0;

    private Material originalMaterial;
    private Material glowMaterial;
    private Renderer objectRenderer;
    private float glowDuration = 1f;  
    private float glowTimer = 0f;
    private bool isGlowing = false;

    [SerializeField] private InteractableObjectGlowing[] parts; 

    private bool isRoot = true; 

    private void Awake()
    {
        isRoot = transform.parent == null || transform.parent.GetComponent<InteractableObjectGlowing>() == null;

        if (isRoot)
        {
            allInteractableObjects.Add(this);
        }
    }

    private void OnDestroy()
    {
        if (isRoot)
        {
            allInteractableObjects.Remove(this);
        }
    }

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogWarning($"No Renderer found on {gameObject.name}. Glowing effect will not be applied.");
            return; 
        }

        originalMaterial = objectRenderer.material;

        glowMaterial = new Material(originalMaterial);
        glowMaterial.SetColor("_Color", Color.blue); 
    }

    private void Update()
    {
        if (objectRenderer == null) return; 

       
        if (isGlowing)
        {
            glowTimer += Time.deltaTime;
            if (glowTimer > glowDuration)
            {
                glowTimer = glowDuration;
            }

            float lerpFactor = glowTimer / glowDuration;
            objectRenderer.material.Lerp(originalMaterial, glowMaterial, lerpFactor);
        }


        if (parts != null && parts.Length > 0)
        {
            bool anyPartGlowing = false;

            foreach (var part in parts)
            {
                if (part.IsGlowing())
                {
                    anyPartGlowing = true;
                    break;
                }
            }

            
            if (anyPartGlowing && !isGlowing)
            {
                StartGlowing(); 
            }
        }

        
        CheckWinCondition();
    }

    public void StartGlowing()
    {
        if (!isGlowing) 
        {
            isGlowing = true;

            if (isRoot)
            {
                glowingCount++;
                Debug.Log($"Object {gameObject.name} is now glowing. Current glowing count: {glowingCount}");
            }

            
            foreach (var part in parts)
            {
                part.StartGlowing(); 
                Debug.Log($"Part {part.gameObject.name} has started glowing.");
            }
        }
    }

    public bool IsGlowing()
    {
        return isGlowing; 
    }

    public static int GetGlowingCount()
    {
        return glowingCount; 
    }

    public static int GetTotalInteractableCount()
    {
        return allInteractableObjects.Count; 
    }

    private void CheckWinCondition()
    {
        int totalInteractableCount = GetTotalInteractableCount();
        int currentGlowingCount = GetGlowingCount();

        Debug.Log($"Total interactable objects: {totalInteractableCount}, Current glowing count: {currentGlowingCount}");

        if (currentGlowingCount == totalInteractableCount)
        {
            Debug.Log("All interactable objects are glowing! You win!");
        }
    }
}
