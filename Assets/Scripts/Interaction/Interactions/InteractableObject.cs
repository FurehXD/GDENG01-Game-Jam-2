using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IHighlightable, IInteractable
{
    [SerializeField]
    private bool _interactable;

    [SerializeField]
    private GameObject[] _interactEffect;

    private Rigidbody _rigidbody;

    private void Start()
    {
        this._rigidbody = GetComponent<Rigidbody>();
    }

    public void Interact()
    {
        if (_interactable)
        {
            if (_interactEffect != null)
            {
                foreach (GameObject effect in _interactEffect)
                {
                    effect.GetComponent<IInteractEffect>().ExecuteEffect();
                }
            }

            Debug.Log(this.gameObject.name + " has been interacted");
        }
    }

    public bool IsInteractable
    {
        get { return _interactable; }
    }
}
