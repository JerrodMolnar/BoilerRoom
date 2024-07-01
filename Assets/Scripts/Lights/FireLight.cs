using System.Collections;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f; 
    private Light _light;
    private float _lightIntensityMinimum = 20f, _lightIntensityMaximum = 100f;
    private float _lightRangeMinimum = 10f, _lightRangeMaximum = 30f;
    private int _positiveIntensity = 4;
    private int _positiveRange = 1;
    private ParticleSystem _fireParticles;
    private AudioSource _fireAudio;
    private WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
        if (_light == null)
        {
            Debug.LogError("Light is null on FireLight on " + gameObject.name);
        }
        _fireParticles = GetComponentInParent<ParticleSystem>();
        if (_fireParticles == null)
        {
            Debug.LogError("Fire Particles is null on Firelight on " + gameObject.name);
        }
        _fireAudio = GetComponentInParent<AudioSource>(); 
        if (_fireAudio == null)
            Debug.LogError("Fire audio source on FireLight is null on " + gameObject.name + " accessing " + transform.parent.name);
    }

    private IEnumerator FireFlicker()
    {
        while (true)
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
            yield return _waitForEndOfFrame;
        }
    }

    public void EnableFire()
    {
        _fireParticles.Play();
        _fireAudio.Play();
        StartCoroutine(FireFlicker());
    }

    public void DisableFire()
    {
        _fireParticles.Stop();
        _fireParticles.Clear();
        _fireAudio.Stop();
        StopCoroutine(FireFlicker());
    }
}
