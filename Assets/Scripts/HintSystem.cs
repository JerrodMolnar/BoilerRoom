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
        if (!_particles.isPlaying)
        {
            _particles.Play();
        }
        else
        {
            StopParticle();
        }
    }

    public void StopParticle()
    {
        _particles.Stop();
        _particles.Clear();
    }

}
