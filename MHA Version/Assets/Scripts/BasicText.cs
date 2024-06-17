using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicText : MonoBehaviour
{
    public TextMeshProUGUI[] textBoxs;
    // Start is called before the first frame update
    public void SetText(string input)
    {
        foreach(TextMeshProUGUI t in textBoxs)
        {
            t.text = input;
        }
    }
}
