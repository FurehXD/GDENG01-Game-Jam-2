using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLights : MonoBehaviour, IInteractEffect
{
    [SerializeField]
    private GameObject[] _lights;

    private bool _lightsOn = true;

    public void ExecuteEffect()
    {
        _lightsOn = !_lightsOn; 

        foreach (GameObject lightObject in _lights)
        {
            Light light = lightObject.GetComponent<Light>();
            if (light != null)
            {
                light.enabled = _lightsOn; 
            }
            else
            {
                Debug.LogWarning("No Light component found on " + lightObject.name);
            }
        }
    }
}
