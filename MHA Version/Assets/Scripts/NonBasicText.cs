using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NonBasicText : MonoBehaviour
{
    public TextMeshProUGUI[] textBoxs;

    string newString = "";
    string backString = "";

    public string beginOrange;
    public string endOrange;
    public string beginGreen;
    public string endGreen;
    public string beginBlue;
    public string endBlue;
    // Start is called before the first frame update
    public void SetText(string input)
    {
        SetUpText(input);

        textBoxs[0].text = backString;
        textBoxs[1].text = newString;
    }

    void SetUpText(string i)
    {
        string s = "";
        string n = "";

        bool addBlue = false;
        bool addOrange = false;
        bool addGreen = false;

        foreach(char c in i)
        {
            if (c.Equals('*'))
            {
                if (!addBlue)
                {
                    addBlue = true;
                    s += beginBlue;
                }
                else
                {
                    addBlue = false;
                    s += endBlue;
                }
            }else
            if (c.Equals('^'))
            {
                if (!addOrange)
                {
                    addOrange = true;
                    s += beginOrange;
                }
                else
                {
                    addOrange = false;
                    s += endOrange;
                }
            }
            else if (c.Equals('&'))
            {
                if (!addGreen)
                {
                    addGreen = true;
                    s += beginGreen;
                }
                else
                {
                    addGreen = false;
                    s += endGreen;
                }
            }
            else
            {
                s += c;
                n += c;
            }
        }

        newString = s;
        backString = n;
    }
}
