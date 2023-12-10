using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private AudioSource _audioSource;

    private void OnEnable()
    {
        BigLightActivation.lightsEvent += PlayAudio;
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();        
    }
    private void PlayAudio()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        else
        {
            _audioSource.Play();
        }
    }

    private void OnDisable()
    {
        BigLightActivation.lightsEvent -= PlayAudio;
    }

}
