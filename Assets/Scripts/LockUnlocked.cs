using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockUnlocked : MonoBehaviour
{
    XRSocketInteractor _interactor;
    bool _locked = true;
    float _speed = .5f;
    WaitForEndOfFrame _waitForEndOfFrame;

    private void Start()
    {
        _waitForEndOfFrame = new WaitForEndOfFrame();
        _interactor = GetComponent<XRSocketInteractor>();
        if (_interactor == null)
            Debug.LogError("Socket interactor not found on LockUnlocked on " + name);
    }

    public void DropLock()
    {
        _locked = false;
        StartCoroutine(destroyTimer());
    }

    private IEnumerator destroyTimer()
    {
        try
        {
            GameObject keySocket = _interactor.GetOldestInteractableSelected().transform.gameObject;
            Destroy(keySocket);
        }
        catch (NullReferenceException)
        {
            Debug.LogWarning("Keysocket on Lock unlocked on " + name + " is null");
        }
        while (!_locked)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.World);
            yield return _waitForEndOfFrame;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _locked = true;
            transform.position = transform.position + (Vector3.up * 0.25f);
        }
    }
}
