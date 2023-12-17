using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodDestroyer : MonoBehaviour
{
    private XRSocketInteractor _interactor;
    private float _speed = 0.5f;
    private bool _isSocketed = false;

    private void Start()
    {
        _interactor = GetComponent<XRSocketInteractor>();
        if (_interactor == null)
            Debug.LogError("Interactor on Food Destroyer is Null");
    }

    private void Update()
    {
        
        if (_interactor.GetOldestInteractableSelected() != null && _isSocketed)
        {
            _interactor.GetOldestInteractableSelected().transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }
    }

    public void SocketedFood()
    {
        _isSocketed = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isSocketed = false;
        Destroy(other, 2f);
    }
}
