using System.Collections;
using UnityEngine;

public class BigLights : MonoBehaviour
{
    private Light _light;
    [SerializeField]
    private Material _florescentMaterial;
    private WaitForSeconds _flicker = new WaitForSeconds(0.05f);
    private WaitForSeconds _longFlicker = new(.25f);

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

    private IEnumerator LightFlicker()
    {
        _light.enabled = true;
        while (true)
        {
            yield return _flicker;
            _light.intensity = Random.Range(5f, 20f);
            yield return _flicker;
            _light.intensity = Random.Range(5f, 20f);
            yield return _flicker;
            _light.intensity = Random.Range(5f, 20f);
            yield return _longFlicker;
            _light.intensity = Random.Range(5f, 20f);
            yield return _flicker;
            _light.intensity = Random.Range(5f, 20f);
            yield return _flicker;
            _light.intensity = Random.Range(5f, 20f);
            yield return _longFlicker;
            _light.intensity = Random.Range(5f, 20f);
            yield return _longFlicker;
            _light.intensity = Random.Range(5f, 20f);
        }
    }

    public void UpdateLights(bool isActive)
    {
        if (isActive)
        {
            StartCoroutine(LightFlicker());
            _florescentMaterial.EnableKeyword("_EMISSION");
        }
        else
        {            
            StopCoroutine(LightFlicker());
            _light.enabled = false;
            _florescentMaterial.DisableKeyword("_EMISSION");
        }
    }
}
