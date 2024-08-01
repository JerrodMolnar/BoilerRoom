using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SilverChainCheat : MonoBehaviour
{
    LockUnlocked lock1, lock2;
    MeshCollider _meshCollider;
    XRGrabInteractable _xrInteractable;
    
    void Start()
    {
        lock1 = transform.GetChild(0).GetComponent<LockUnlocked>();
        if (lock1 == null)
        {
            Debug.LogError("Did not successfully find lock1 on SilverChainCheat on " + name);
        }
        lock2 = transform.GetChild(1).GetComponent<LockUnlocked>();
        if (lock2 == null)
        { 
            Debug.LogError("Did not successfully find lock2 on SiverChainCheat on " + name); 
        }
        _meshCollider = GetComponent<MeshCollider>();
        if ( _meshCollider == null )
        {
            Debug.LogError("Did not find meshcollider on SilverChainCheat on " + name);
        }
        _xrInteractable = GetComponent<XRGrabInteractable>();
        if ( _xrInteractable == null )
        {
            Debug.LogError("Did not find XRGrabInteractable on SilverChainCheat on " + name);
        }
    }

    public void CheatToEnd()
    {
        if (lock1 != null)
        {
            lock1.DropLock();
        }
        if (lock2 != null)
        {
            lock2.gameObject.SetActive(true);
            lock2.DropLock();
        }
        
        _meshCollider.enabled = true;
        _xrInteractable.enabled = true;        
    }
}
