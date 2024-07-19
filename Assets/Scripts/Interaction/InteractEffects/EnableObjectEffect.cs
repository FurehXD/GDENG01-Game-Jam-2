using UnityEngine;

public class OpenDoorEffect : MonoBehaviour, IInteractEffect
{

    public void ExecuteEffect()
    {
       this.gameObject.SetActive(true);
    }
}
