using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockUnlocked : MonoBehaviour
{
    [SerializeField] private float _timeToWait = 5f;
    XRSocketInteractor _interactor;
    bool _locked = true;
    float _speed = .5f;

    private void Start()
    {
        _interactor = GetComponent<XRSocketInteractor>();
        if (_interactor == null)
            Debug.LogError("Socket interactor not found on LockUnlocked on " + name);
    }

    private void Update()
    {
        if (_locked) return;
        else transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.World);
    }

    public void DropLock()
    {
        StartCoroutine(destroyTimer());
        _locked = false;
    }

    private IEnumerator destroyTimer()
    {
        Destroy(_interactor.GetOldestInteractableSelected().transform.gameObject);
        yield return new WaitForSeconds(_timeToWait);        
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _locked = true;
            Debug.LogWarning("Lock hit ground on " + transform.parent.name);
            transform.position = transform.position + (Vector3.up * 0.25f);
        }
    }
}
