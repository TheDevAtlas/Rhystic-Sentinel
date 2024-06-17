using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColorChange : MonoBehaviour
{
    public TextMeshProUGUI textObj;

    public Color start;
    public Color different;

    public bool isDifferent;

    public void changeDifferent(bool b){
        isDifferent = b;
    }

    void Update(){
        if(!isDifferent){
            textObj.color = start;
        }else{
            textObj.color = different;
        }
    }
}
