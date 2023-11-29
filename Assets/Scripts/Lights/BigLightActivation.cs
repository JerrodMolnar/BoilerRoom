using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLightActivation : MonoBehaviour
{
    public delegate void LightsStatusChange();
    public static event LightsStatusChange lightsEvent;
    [SerializeField]
    private bool _lightsOn = false;
    private bool _startingLights;
    private bool _firstIteration = true;

    private void Start()
    {
        _startingLights = _lightsOn;
    }

    public void StatusChange()
    {
        if (lightsEvent != null)
        {
            lightsEvent();
        }
    }

    private void Update()
    {
        if (_firstIteration)
        {
            _firstIteration = false;
            if (_lightsOn)
            {
                StatusChange();
            }
        }
    }
}
