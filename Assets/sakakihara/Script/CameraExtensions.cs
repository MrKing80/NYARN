using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraExtensions
{
    //カメラ拡張用スクリプト
    //表示レイヤーを変更するために必要

    //どこにも付いてないけど消すとたぶんどえらいことになるから消さないでね

    //引用元：https://baba-s.hatenablog.com/entry/2018/01/23/083100
    //参考サイト：https://teratail.com/questions/289846

    public static void LayerCullingShow(this Camera cam, int layerMask)
    {
        cam.cullingMask |= layerMask;
    }

    public static void LayerCullingShow(this Camera cam, string layer)
    {
        LayerCullingShow(cam, 1 << LayerMask.NameToLayer(layer));
    }

    public static void LayerCullingHide(this Camera cam, int layerMask)
    {
        cam.cullingMask &= ~layerMask;
    }

    public static void LayerCullingHide(this Camera cam, string layer)
    {
        LayerCullingHide(cam, 1 << LayerMask.NameToLayer(layer));
    }

    public static void LayerCullingToggle(this Camera cam, int layerMask)
    {
        cam.cullingMask ^= layerMask;
    }

    public static void LayerCullingToggle(this Camera cam, string layer)
    {
        LayerCullingToggle(cam, 1 << LayerMask.NameToLayer(layer));
    }

    public static bool LayerCullingIncludes(this Camera cam, int layerMask)
    {
        return (cam.cullingMask & layerMask) > 0;
    }

    public static bool LayerCullingIncludes(this Camera cam, string layer)
    {
        return LayerCullingIncludes(cam, 1 << LayerMask.NameToLayer(layer));
    }

    public static void LayerCullingToggle(this Camera cam, int layerMask, bool isOn)
    {
        bool included = LayerCullingIncludes(cam, layerMask);
        if (isOn && !included)
        {
            LayerCullingShow(cam, layerMask);
        }
        else if (!isOn && included)
        {
            LayerCullingHide(cam, layerMask);
        }
    }

    public static void LayerCullingToggle(this Camera cam, string layer, bool isOn)
    {
        LayerCullingToggle(cam, 1 << LayerMask.NameToLayer(layer), isOn);
    }
}
