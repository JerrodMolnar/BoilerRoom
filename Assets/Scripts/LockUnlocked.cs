using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockUnlocked : MonoBehaviour
{
    [SerializeField] private float _timeToWait = 5f;
    [SerializeField] private float _speed = 1f;
    XRSocketInteractor _interactor;
    Rigidbody _rigidbody;

    private void Start()
    {
        _interactor = GetComponent<XRSocketInteractor>();
        if (_interactor == null)
            Debug.LogError("Socket interactor not found on LockUnlocked on " + name);
    }    

    public void DropLock()
    {
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.useGravity = true;
        StartCoroutine(destroyTimer());
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
            Debug.LogWarning("Lock hit ground on " + transform.parent.name);
            _rigidbody.useGravity = false;
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
