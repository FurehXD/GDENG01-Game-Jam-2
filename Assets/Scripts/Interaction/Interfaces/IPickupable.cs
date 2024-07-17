using UnityEngine;

public interface IPickupable
{
    void Pickup(Transform playerTransform);
    void Drop();
}
