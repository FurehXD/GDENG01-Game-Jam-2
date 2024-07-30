using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleMaterial : MonoBehaviour, IInteractEffect
{
    public GameObject targetObject;

    public List<Material> materials;

    private int currentMaterialIndex = 0;

    private void Start()
    {
        
    }

    

    public void ExecuteEffect()
    {
        if (targetObject != null && materials.Count > 0)
        {
            currentMaterialIndex = (currentMaterialIndex + 1) % materials.Count;
            SetMaterial(currentMaterialIndex);
        }
    }

    private void SetMaterial(int index)
    {
        Renderer renderer = targetObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = materials[index];
        }
    }
}
