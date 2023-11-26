using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLights : MonoBehaviour
{
    private Light _light;
    [SerializeField]
    private Material _florescentMaterial;

    void Start()
    {
        _light = GetComponent<Light>();
        if (_light == null)
            Debug.LogError("Light is Null on BigLights");
        if (_florescentMaterial == null)
        {
            Debug.LogError("Material missing for florescent lights.");
        }
    }

    private void OnEnable()
    {
        BigLightActivation.lightsEvent += UpdateLights;
    }

    private void OnDisable()
    {
        BigLightActivation.lightsEvent -= UpdateLights;
    }

    public void UpdateLights()
    {
        if (!_light.enabled)
        {
            _light.enabled = true;
            _florescentMaterial.EnableKeyword("_EMISSION");
        }
        else
        {
            _light.enabled = false;
            _florescentMaterial.DisableKeyword("_EMISSION");
        }
    }
}
