using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("Highlighting")]
    [SerializeField]
    private Material _highlightMaterial;
    private Material _originalMaterial;
    private Renderer _highlightedRenderer;

    private void Start()
    {
        _holdPosition = new GameObject("HoldPosition").transform;
        _holdPosition.SetParent(_cameraTransform);
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
        //Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * _interactDistance, Color.red);

        if (!_hasObject)
        {
            HighlightObject();
        }
        else
        {
            ClearHighlight();
        }
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
                ClearHighlight();
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

    private void HighlightObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _interactDistance))
        {
            IHighlightable highlightable = hit.collider.GetComponent<IHighlightable>();
            if (highlightable != null)
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null && renderer != _highlightedRenderer)
                {
                    ClearHighlight();
                    _originalMaterial = renderer.material;
                    renderer.material = _highlightMaterial;
                    _highlightedRenderer = renderer;
                }
            }
            else
            {
                ClearHighlight();
            }
        }
        else
        {
            ClearHighlight();
        }
    }

    private void ClearHighlight()
    {
        if (_highlightedRenderer != null)
        {
            _highlightedRenderer.material = _originalMaterial;
            _highlightedRenderer = null;
        }
    }
}
