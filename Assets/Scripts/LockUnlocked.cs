using System.Collections;
using UnityEngine;

public class LockUnlocked : MonoBehaviour
{
    private bool locked = true;
    [SerializeField] private float _timeToWait = 5f;
    [SerializeField] private float _speed = 1f;

    private void Update()
    {
        if (!locked)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.World);
        }
    }

    public void DropLock()
    {
        locked = false;
        Destroy(gameObject, _timeToWait);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _speed = 0;
        }
    }
}
