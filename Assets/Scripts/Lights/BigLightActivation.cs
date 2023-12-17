using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BigLightActivation : MonoBehaviour
{
    public delegate void LightsStatusChange(bool isActive);
    public static event LightsStatusChange lightsEvent;
    [SerializeField]
    private bool _lightsOn = false;

    public void LightsActivate()
    {
        lightsEvent?.Invoke(true);
    }

    public void LightsDeactivate()
    {
        lightsEvent?.Invoke(false);
    }

    private void Start()
    {
        if (!_lightsOn)
        {
            StartCoroutine(LightsOff());
        }
        else
        {
            StartCoroutine(LightsOn());
        }
    }

    private IEnumerator LightsOff()
    {
        yield return new WaitForEndOfFrame();
        LightsDeactivate();
    }

    private IEnumerator LightsOn()
    {
        yield return new WaitForSeconds(0.5f);
        LightsActivate();
    }
}
