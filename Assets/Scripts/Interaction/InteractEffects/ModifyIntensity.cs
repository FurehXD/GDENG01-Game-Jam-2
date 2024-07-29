using UnityEngine;

public class ModifyIntensity : MonoBehaviour, IInteractEffect
{
    [SerializeField]
    private Light _light;

    private float _originalIntensity;
    private float _modifiedIntensity;
    private bool _isModified = false;

    [SerializeField]
    private float _newIntensity = 2.0f; // Adjust this value as needed

    

    private void Start()
    {
        if (_light != null)
        {
            _originalIntensity = _light.intensity;
            _modifiedIntensity = _newIntensity;
        }
    }

    public void ExecuteEffect()
    {
        if (_light != null)
        {
            if (_isModified)
            {
                _light.intensity = _originalIntensity;
            }
            else
            {
                _light.intensity = _modifiedIntensity;
            }
            _isModified = !_isModified;
        }
    }
}