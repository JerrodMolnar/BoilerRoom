using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HintSystem : MonoBehaviour
{
    private ParticleSystem _particles;
    private Transform _transform;

    private void Start()
    {
        _particles = GetComponent<ParticleSystem>();
        if (_particles == null)
            Debug.LogError("Particle System on Hint System is null on " + gameObject.name);
    }

    public void StartParticle(Transform t)
    {
        _transform = t;
        transform.position = _transform.position;
        _particles.Play();
        Debug.Log("Particles played on " + t.name);
    }

    public void StopParticle()
    {
        _particles.Stop();
        _particles.Clear();
        Debug.Log("Particles Stopped on " + _transform.name);
    }

}
