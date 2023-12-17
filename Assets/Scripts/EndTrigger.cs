using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _endCanvas, _lifeText;
    private float _lifeSeconds, _lifeMinutes, _lifeHours;
    private string _timeText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_endCanvas != null)
            {
                _endCanvas.SetActive(true);
            }
            else
            {
                Debug.Log("End Canvas not found on EndTrigger");
            }
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
            _lifeText.GetComponent<TextMeshPro>().text = _timeText;
            Debug.Log(_timeText);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
