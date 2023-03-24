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
        GetComponent<MeshRenderer>().material = SolidMaterial;
    }
    public void ShowTransparent()
    {
        GetComponent<MeshRenderer>().material = TransparentMaterial;
    }


}
