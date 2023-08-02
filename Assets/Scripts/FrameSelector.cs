using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSelector : MonoBehaviour
{
    int index;
    public SpriteRenderer sr;
    public Sprite[] sprites;

    public void changeIndex(int i)
    {
        index = i;
        sr.sprite = sprites[index];
    }
}
