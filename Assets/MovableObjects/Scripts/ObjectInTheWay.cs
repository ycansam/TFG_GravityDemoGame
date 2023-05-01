using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInTheWay : MonoBehaviour
{
    public Material SolidMaterial;
    public Material TransparentMaterial;
    private void Awake()
    {
        ShowSolid();
    }
    public void ShowSolid()
    {
        if (this)
            GetComponent<MeshRenderer>().material = SolidMaterial;
    }
    public void ShowTransparent()
    {
        if (this)
            GetComponent<MeshRenderer>().material = TransparentMaterial;
    }


}
