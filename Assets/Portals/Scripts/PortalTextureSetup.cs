using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Camera> cams = new List<Camera>();
    public List<Material> mats = new List<Material>();
    public static string playerInCube = "";

    void Start()
    {
        for (int i = 0; i < cams.Count; i++)
        {
            if (cams[i].targetTexture != null)
            {
                cams[i].targetTexture.Release();
            }
            cams[i].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            mats[i].mainTexture = cams[i].targetTexture;
        }
    }

    private void Update()
    {
        if (playerInCube == "Cube 3")
        {
            cams[3].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            mats[1].mainTexture = cams[3].targetTexture;
            Debug.Log(playerInCube);
        }
    }
}
