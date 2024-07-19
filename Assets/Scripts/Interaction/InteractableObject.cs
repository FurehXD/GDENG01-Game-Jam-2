using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable, IPickupable
{
    [SerializeField]
    private bool _interactable;
    [SerializeField]
    private bool _pickupable;
    [SerializeField]
    private GameObject _interactEffect;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Interact()
    {
        if (_interactable)
        {
            if(_interactEffect != null)
            {
                this._interactEffect.GetComponent<IInteractEffect>().ExecuteEffect();
            }

            Debug.Log(this.gameObject.name + " has been interacted");
        }
            
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

    public bool IsInteractable
    {
        get { return _interactable; }
    }

    public bool IsPickupable
    {
        get { return _pickupable; }
    }
}
