using UnityEngine;

public class WinConditionChecker : MonoBehaviour
{
    private bool _isFinished = false;
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
        if (_isFinished == false)
        {
            PuzzleManager.Instance.DecrementPuzzlesRemaining();
            _isFinished = true;
        }
    }
}
