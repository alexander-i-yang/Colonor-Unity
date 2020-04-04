using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyLayerMaskExtensions
{
    public static bool Contains(this LayerMask layers, GameObject gameObject)
    {
        return 0 != (layers.value & 1 << gameObject.layer);
    }

    public static void PrintLayers(LayerMask layerMask)
    {
        string ret = "";
        for (int i = 0; i < 32; i++)
        {
            if (layerMask == (layerMask | (1 << i)))
            {
                ret += "1";
            }
            else
            {
                ret += "0";
            }
        }
        Debug.Log(ret);
    }
}