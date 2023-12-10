using UnityEngine;

public class BigLightActivation : MonoBehaviour
{
    public delegate void LightsStatusChange();
    public static event LightsStatusChange lightsEvent;
    [SerializeField]
    private bool _lightsOn = false;

    public void StatusChange()
    {
        lightsEvent?.Invoke();
    }

    private void Start()
    {
        if (_lightsOn)
        {
            StatusChange();
        }
    }
}
