using UnityEngine;

public class DrawerCloser : MonoBehaviour
{
    private bool _drawerActivate = false;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.localPosition;
    }

    public void GrabDrawer()
    {
        _drawerActivate = !_drawerActivate;
        if (_drawerActivate)
        {
            transform.localPosition = new Vector3(_startPosition.x, _startPosition.y, _startPosition.z + 0.3f);
            transform.GetComponentInChildren<Transform>().localPosition = new Vector3(_startPosition.x, _startPosition.y, _startPosition.z + 0.3f);
        }
        else
        {
            transform.localPosition = _startPosition;
            transform.GetComponentInChildren<Transform>().localPosition = _startPosition;
        }
    }
}
