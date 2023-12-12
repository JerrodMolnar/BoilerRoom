using UnityEngine;

public class DrawerCloser : MonoBehaviour
{
    private bool _drawerActivate = false;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (_drawerActivate)
        {
            return;
        }
        transform.localPosition = _startPosition;
    }

    public void GrabDrawer()
    {
        _drawerActivate = true;
        Debug.LogWarning("Drawer Grabbed " + name);
    }
}
