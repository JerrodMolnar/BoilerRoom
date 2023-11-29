using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorChange : MonoBehaviour
{
    private Material _material;

    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Material>();
    }

    public void ColorChange()
    {
        _material.color = Color.red;
    }
}
