using UnityEngine;

public class WinConditionChecker : MonoBehaviour
{
    private void Update()
    {
        
        if (InteractableObjectGlowing.GetGlowingCount() >= InteractableObjectGlowing.GetTotalInteractableCount())
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        
        Debug.Log("You Win! All objects are glowing.");
        
    }
}
