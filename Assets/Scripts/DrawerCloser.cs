using UnityEngine;

public class DrawerCloser : MonoBehaviour
{

    // Update is called once per frame
    void Update()
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
}
