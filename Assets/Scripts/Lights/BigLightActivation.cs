using System.Collections;
using UnityEngine;

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
        if (_lightsOn)
        {
            StartCoroutine(LightsOn());
        }
    }

    private IEnumerator LightsOn()
    {
        yield return new WaitForSeconds(.5f);
        LightsActivate();
    }
}
