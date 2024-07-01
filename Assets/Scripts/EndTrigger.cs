using TMPro;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _endCanvas;
    [SerializeField]
    private TMP_Text _lifeText;
    private float _lifeSeconds, _lifeMinutes, _lifeHours;
    private string _timeText;

    private void Start()
    {
        if (_endCanvas == null)
        {
            Debug.LogError("End Canvas is null on EndTrigger on " + gameObject.name);
        }

        if (_lifeText == null)
        {
            Debug.LogError("Life Text is null on EndTrigger on " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _endCanvas.SetActive(true);
            _lifeSeconds = Time.time;
            if (_lifeSeconds > 60)
            {
                _lifeMinutes = _lifeSeconds / 60;
                _lifeSeconds = _lifeSeconds % 60;
                if (_lifeMinutes > 60)
                {
                    _lifeHours = _lifeMinutes / 60;
                    _lifeMinutes = _lifeMinutes % 60;
                }
            }
            _timeText = "This took " + _lifeHours + " hours " + _lifeMinutes + " minutes "
                + _lifeSeconds + " seconds.";
            _lifeText.text = _timeText;
            Debug.Log(_timeText);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
