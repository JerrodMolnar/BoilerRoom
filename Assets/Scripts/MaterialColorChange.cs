using UnityEngine;

public class MaterialColorChange : MonoBehaviour
{
    private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        if (_material == null)
            Debug.LogError("Material not found on Material Color Change on " + name);
    }

    public void ColorChange()
    {
        _material.color = Color.red;
    }
}
