using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour, IHighlightable, IPickupable
{
    [SerializeField]
    private bool _pickupable;
    [SerializeField]
    private GameObject _interactEffect;

    private Rigidbody _rigidbody;

    private void Start()
    {
        this._rigidbody = GetComponent<Rigidbody>();
    }
    public void Pickup(Transform playerTransform)
    {
        if (_pickupable)
        {
            _rigidbody.isKinematic = true;
            transform.SetParent(playerTransform);
            transform.localPosition = Vector3.zero;
            Debug.Log(this.gameObject.name + " has been picked up");
        }
    }

    public void Drop()
    {
        if (_pickupable)
        {
            _rigidbody.isKinematic = false;
            transform.SetParent(null);
            Debug.Log(this.gameObject.name + " has been dropped");
        }
    }

    public bool IsPickupable
    {
        get { return _pickupable; }
    }
}
