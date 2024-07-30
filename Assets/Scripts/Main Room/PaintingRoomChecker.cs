using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingRoomChecker : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> firstObjectList;

    [SerializeField]
    private List<GameObject> secondObjectList;

    private bool _isFinished = false;

    private void Update()
    {
        CheckMaterials();
    }

    public void CheckMaterials()
    {
        // Ensure both lists have the same number of elements
        if (firstObjectList.Count != secondObjectList.Count)
        {
            Debug.LogError("Both lists must have the same number of elements.");
            return;
        }

        for (int i = 0; i < firstObjectList.Count; i++)
        {
            Renderer firstRenderer = firstObjectList[i].GetComponent<Renderer>();
            Renderer secondRenderer = secondObjectList[i].GetComponent<Renderer>();

            if (firstRenderer != null && secondRenderer != null)
            {
                if (firstRenderer.material.name == secondRenderer.material.name)
                {
                    if(_isFinished == false)
                    {
                        PuzzleManager.Instance.DecrementPuzzlesRemaining();
                        _isFinished = true;
                    }
                        
                }
                
            }
            
        }
    }
}
