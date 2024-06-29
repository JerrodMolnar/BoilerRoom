using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Lever : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private XRLever _lightLever;

    private void OnEnable()
    {
        BigLightActivation.lightsEvent += PlayAudio;
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();      
        if (_lightLever == null)
        {
            Debug.LogError("XR Lever is not found on Lever");
        }
    }
    private void PlayAudio(bool isActive)
    {
        if (!isActive)
        {
            _lightLever.value = false;
            _audioSource.Stop();
        }
        else
        {
            _lightLever.value = true;
            _audioSource.Play();
        }
    }

    private void OnDisable()
    {
        BigLightActivation.lightsEvent -= PlayAudio;
    }

}
