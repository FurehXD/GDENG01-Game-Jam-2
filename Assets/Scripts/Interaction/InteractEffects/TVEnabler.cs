using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVEnabler : MonoBehaviour, IInteractEffect
{
    [SerializeField]
    private List<GameObject> objectsToEnable;

    [SerializeField]
    private List<Material> materials;

    [SerializeField]
    private GameObject screenObjectEffect;
    [SerializeField]
    private GameObject screenObjectNoEffect;

    private void Start()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(false);
        }

        this.screenObjectEffect.SetActive(true);
        this.screenObjectNoEffect.SetActive(false);
    }

    public void ExecuteEffect()
    {
        if (objectsToEnable != null && materials != null && materials.Count > 0)
        {
            if (materials.Count < objectsToEnable.Count)
            {
                Debug.LogError("Not enough materials for the objects to enable.");
                return;
            }

            List<Material> shuffledMaterials = new List<Material>(materials);
            ShuffleList(shuffledMaterials);

            for (int i = 0; i < objectsToEnable.Count; i++)
            {
                GameObject obj = objectsToEnable[i];
                if (obj != null)
                {
                    obj.SetActive(true);

                    Renderer renderer = obj.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        renderer.material = shuffledMaterials[i];
                    }
                    
                }
            }
        }
        this.screenObjectEffect.SetActive(false);
        this.screenObjectNoEffect.SetActive(true);
    }

    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
