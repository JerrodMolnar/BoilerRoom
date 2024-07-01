using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodDestroyer : MonoBehaviour
{
    private XRSocketInteractor _interactor;
    private float _speed = 1.5f;
    private bool _isSocketed = false;
    private WaitForEndOfFrame _waitForEndOfFrame;

    private void Start()
    {
        _waitForEndOfFrame = new WaitForEndOfFrame();
        _interactor = GetComponent<XRSocketInteractor>();
        if (_interactor == null)
            Debug.LogError("Interactor on Food Destroyer is Null");
    }

    private IEnumerator EatFood()
    {
        IXRSelectInteractable insertedFood = _interactor.GetOldestInteractableSelected();
        while (_isSocketed)
        {
            insertedFood?.transform.Translate(Vector3.back * _speed * Time.deltaTime);
            yield return _waitForEndOfFrame;
        }
    }

    public void SocketedFood()
    {
        _isSocketed = true;
        StartCoroutine(EatFood());
    }

    private void OnTriggerExit(Collider other)
    {
        _isSocketed = false;
        StopCoroutine(EatFood());
        Destroy(other, 2f);
    }
}
