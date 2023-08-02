using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardArtScale : MonoBehaviour
{
    RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }
    public void OnScaleChange(float s)
    {
        rt.localScale = new Vector3(s, s, s);
    }

    public void OnXChange(float s)
    {
        rt.localPosition = new Vector3(s, rt.localPosition.y, rt.localPosition.z);
    }

    public void OnYChange(float s)
    {
        rt.localPosition = new Vector3(rt.localPosition.x, s, rt.localPosition.z);
    }
}
