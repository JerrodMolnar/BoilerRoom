using UnityEngine;

public class FrameID : MonoBehaviour
{
    [SerializeField] int _frameID;

    public int GetID()
    {
        return _frameID;
    }
}
