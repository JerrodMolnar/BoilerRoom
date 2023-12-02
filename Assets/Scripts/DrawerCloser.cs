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
            if (transform.localPosition.z < 0)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            }
            else if (transform.localPosition.z > .3f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.3f);
            }
        }
        else
        {
            transform.localPosition = _startPosition;
        }

    }

    public void GrabDrawer()
    {
        _drawerActivate = true;
    }
}
