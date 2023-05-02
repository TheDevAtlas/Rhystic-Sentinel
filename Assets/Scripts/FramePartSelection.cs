using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FramePartSelection : MonoBehaviour
{
    public SpriteRenderer framePart;
    public TextMeshProUGUI subIndexText;

    public List<Frame> frameList;
    public int frameIndex;
    public int subIndex;

    public void changeFrame(int n){ // Modern UI Pack Sends Index of Current Button //
        frameIndex = n;
    }

    public void changeSub(int n){
        if(subIndex + n > frameList[frameIndex].list.Count - 1){
            subIndex = 0;
        }else if(subIndex + n < 0){
            subIndex = frameList[frameIndex].list.Count - 1;
        }else{
            subIndex += n;
        }
    }

    void Update(){
        if(subIndex > frameList[frameIndex].list.Count - 1){
            subIndex = 0;
        }else if(subIndex < 0){
            subIndex = frameList[frameIndex].list.Count - 1;
        }

        framePart.sprite = frameList[frameIndex].list[subIndex];

        subIndexText.text = subIndex.ToString();
    }
}

[System.Serializable]
public class Frame
{
    public List<Sprite> list;
}