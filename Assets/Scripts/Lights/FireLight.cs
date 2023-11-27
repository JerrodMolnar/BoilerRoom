using UnityEngine;

public class FireLight : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f; 
    private Light _light;
    private float _lightIntensityMinimum = 20f, _lightIntensityMaximum = 100f;
    private float _lightRangeMinimum = 10f, _lightRangeMaximum = 30f;
    private int _positiveIntensity = 1;
    private int _positiveRange = 1;

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        if (_light == null)
        {
            Debug.LogError("Light is null on FireLight");
        }
    }

    // Update is called once per frame
    void Update()
    {

        _light.intensity += _speed * _positiveIntensity;
        _light.range += _speed * _positiveRange;

        if (_light.intensity < _lightIntensityMinimum || _light.intensity > _lightIntensityMaximum)
        {
            _positiveIntensity = -_positiveIntensity;
        }

        if (_light.range < _lightRangeMinimum || _light.range > _lightRangeMaximum)
        { 
            _positiveRange = -_positiveRange; 
        }
    }
}
