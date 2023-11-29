using System.Collections;
using UnityEngine;

public class LockUnlocked : MonoBehaviour
{
    private bool locked = true;
    [SerializeField] private float _timeToWait = 5f;
    [SerializeField] private float _speed = 1f;
    private bool coroutine = false;

    private void Update()
    {
        if (!locked)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
            if (!coroutine)
            {
                coroutine = true;
                StartCoroutine(DisappearTimer());
            }
        }
    }

    private IEnumerator DisappearTimer()
    {
        yield return new WaitForSeconds(_timeToWait);
        Destroy(gameObject);
    }

    public void DropLock()
    {
        locked = false;
    }
}
