using UnityEngine;

public class DrawerCloser : MonoBehaviour
{
    private bool _drawerActivate = false;
    private Vector3 _startPosition, _endPosition, _handleStartPosition, _handleEndPosition;
    private Transform _handleTransform;


    private void Start()
    {
        _startPosition = transform.localPosition;
        _endPosition = new Vector3(_startPosition.x, _startPosition.y, _startPosition.z + 0.3f);
        _handleTransform = transform.GetComponentInChildren<Transform>();
        if (_handleTransform != null)
        {
            _handleEndPosition = new Vector3(_handleStartPosition.x, _handleStartPosition.y, _handleStartPosition.z + 0.3f);
            _handleStartPosition = _handleTransform.localPosition;
        }
        else
        {
            Debug.LogError("Transform of handle not found on " + gameObject.name);
        }
    }

    public void GrabDrawer()
    {
        _drawerActivate = !_drawerActivate;
        if (_drawerActivate)
        {
            transform.localPosition = _endPosition;
            _handleTransform.localPosition = _endPosition;
        }
        else
        {
            transform.localPosition = _startPosition;
            _handleTransform.localPosition = _handleStartPosition;
        }
    }
}
