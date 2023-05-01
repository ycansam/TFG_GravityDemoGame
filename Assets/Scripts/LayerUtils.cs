using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerUtils
{
    // CreateLayerMask(false, 2, 5, 7); // only cast against the layers 2, 5, 7 and ignore all others
    // CreateLayerMask(true, 0, 1, 6, 8); // cast against all layers except layers 0, 1, 6, 8
    public static int CreateLayerMask(bool aExclude, params int[] aLayers)
    {
        int v = 0;
        foreach (var L in aLayers)
            v |= 1 << L;
        if (aExclude)
            v = ~v;
        return v;
    }
}
