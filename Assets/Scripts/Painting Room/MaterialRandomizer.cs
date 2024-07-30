using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRandomizer : MonoBehaviour
{
    public List<GameObject> objectsWithShapes;

    public List<Material> shapeMaterials;

    public float randomizeInterval = 5f;

    private void Start()
    {
        StartCoroutine(RandomizeMaterials());
    }

    private IEnumerator RandomizeMaterials()
    {
        while (true)
        {
            foreach (GameObject obj in objectsWithShapes)
            {
                foreach (Transform child in obj.transform)
                {
                    Transform shapeTransform = child.Find("Shape");
                    if (shapeTransform != null)
                    {
                        Renderer shapeRenderer = shapeTransform.GetComponent<Renderer>();
                        if (shapeRenderer != null)
                        {
                            int randomIndex = Random.Range(0, shapeMaterials.Count);
                            shapeRenderer.material = shapeMaterials[randomIndex];
                        }
                    }
                }
            }

            yield return new WaitForSeconds(randomizeInterval);
        }
    }
}
