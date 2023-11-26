using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLightActivation : MonoBehaviour
{
    public delegate void LightsStatusChange();
    public static event LightsStatusChange lightsEvent;

    public void StatusChange()
    {
        if (lightsEvent != null)
        {
            lightsEvent();
        }
    }
}
