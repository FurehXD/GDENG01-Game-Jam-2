using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField]
    private float _interactDistance = 3.0f;
    [SerializeField]
    private bool _hasObject = false;

    private IPickupable _currentObject;
    private Transform _holdPosition;

    [Header("Camera")]
    [SerializeField]
    private Transform _cameraTransform;

    private void Start()
    {
        _holdPosition = new GameObject("HoldPosition").transform;
        _holdPosition.SetParent(transform);
        _holdPosition.localPosition = new Vector3(0, 0, 2);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_hasObject)
            {
                DropObject();
            }
            else
            {
                InteractWithObject();
            }
        }

        // Debugging raycast
        Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * _interactDistance, Color.red);
    }

    private void InteractWithObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }

            IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
            if (pickupable != null)
            {
                _hasObject = true;
                _currentObject = pickupable;
                pickupable.Pickup(_holdPosition);
            }
        }
    }

    private void DropObject()
    {
        if (_currentObject != null)
        {
            _currentObject.Drop();
            _currentObject = null;
            _hasObject = false;
        }
    }
}
