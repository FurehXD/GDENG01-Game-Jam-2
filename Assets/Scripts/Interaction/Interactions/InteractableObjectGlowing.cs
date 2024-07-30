using UnityEngine;
using System.Collections.Generic;

public class InteractableObjectGlowing : MonoBehaviour
{
    private static List<InteractableObjectGlowing> allInteractableObjects = new List<InteractableObjectGlowing>();
    private static int glowingCount = 0; // Count of glowing objects

    private Material originalMaterial;
    private Material glowMaterial;
    private Renderer objectRenderer;
    private float glowDuration = 1f;  // Duration for the glow to fully appear
    private float glowTimer = 0f;
    private bool isGlowing = false;

    [SerializeField] private InteractableObjectGlowing[] parts; // References to the parts (body, screen, etc.)

    private bool isRoot = true; // Flag to check if this is a root object

    private void Awake()
    {
        // Determine if this object is a root object
        isRoot = transform.parent == null || transform.parent.GetComponent<InteractableObjectGlowing>() == null;

        // Add this instance to the list if it's a root object
        if (isRoot)
        {
            allInteractableObjects.Add(this);
        }
    }

    private void OnDestroy()
    {
        // Remove this instance from the list when destroyed if it's a root object
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
            return; // Exit if no Renderer is attached
        }

        originalMaterial = objectRenderer.material;

        // Create a new material for glowing
        glowMaterial = new Material(originalMaterial);
        glowMaterial.SetColor("_Color", Color.blue); // Change this to the property you want to modify
    }

    private void Update()
    {
        if (objectRenderer == null) return; // Exit if no Renderer is available

        // Handle glowing effect
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

        // Check if any parts are glowing
        if (parts != null && parts.Length > 0)
        {
            bool anyPartGlowing = false;

            foreach (var part in parts)
            {
                if (part.IsGlowing()) // Check if any part is glowing
                {
                    anyPartGlowing = true;
                    break;
                }
            }

            // If any part is glowing and the parent is not glowing, start glowing
            if (anyPartGlowing && !isGlowing)
            {
                StartGlowing(); // Start glowing if any part is glowing
            }
        }

        // Check for win condition
        CheckWinCondition();
    }

    public void StartGlowing()
    {
        if (!isGlowing) // Only increment if it's not already glowing
        {
            isGlowing = true;

            if (isRoot)
            {
                glowingCount++; // Increment the count of glowing objects only if it's a root object
                Debug.Log($"Object {gameObject.name} is now glowing. Current glowing count: {glowingCount}");
            }

            // Make all child parts glow as well
            foreach (var part in parts)
            {
                part.StartGlowing(); // Ensure all parts start glowing
                Debug.Log($"Part {part.gameObject.name} has started glowing.");
            }
        }
    }

    public bool IsGlowing()
    {
        return isGlowing; // Return the glowing state
    }

    public static int GetGlowingCount()
    {
        return glowingCount; // Return the current count of glowing objects
    }

    public static int GetTotalInteractableCount()
    {
        return allInteractableObjects.Count; // Return total interactable objects
    }

    private void CheckWinCondition()
    {
        int totalInteractableCount = GetTotalInteractableCount();
        int currentGlowingCount = GetGlowingCount();

        Debug.Log($"Total interactable objects: {totalInteractableCount}, Current glowing count: {currentGlowingCount}");

        if (currentGlowingCount == totalInteractableCount)
        {
            Debug.Log("All interactable objects are glowing! You win!");
            // Implement win logic here (e.g., show win UI, stop the game, etc.)
        }
    }
}
