using UnityEngine;

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
    }

    public void StopParticle()
    {
        _particles.Stop();
        _particles.Clear();
    }

}
