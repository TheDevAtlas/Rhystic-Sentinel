using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class DisplayText : MonoBehaviour
{
    public ChatGPT gpt;

    public TextMeshProUGUI card_name;
    public TextMeshProUGUI mana_cost;
    public TextMeshProUGUI oracle_text;
    public TextMeshProUGUI type;
    public TextMeshProUGUI pt;

    public string fonty;

    public bool isMulti = false;
    public bool isWhite = false;
    public bool isBlue = false;
    public bool isBlack = false;
    public bool isRed = false;
    public bool isGreen = false;

    void Update(){
        card_name.text = gpt.name;

        ManaConvert();

        OracleTextConvert();
        
        pt.text = gpt.powertough;
        type.text = gpt.type;
    }

    public void ManaConvert(){
        mana_cost.text = "";
        string manaCost = gpt.mana_cost.Replace("{","").Replace("}","").Replace(" ","");

        isMulti = false;
        isWhite = false;
        isBlue = false;
        isBlack = false;
        isRed = false;
        isGreen = false;

        foreach (char l in manaCost)
        {
            if(l == 'w' || l == 'W')
            {
                mana_cost.text += "<cspace=0.025em><voffset=-6>o </voffset></cspace><color=#FFFBD5>o</color>";
                isWhite = true;
            }

            else if (l == 'u' || l == 'U')
            {
                mana_cost.text += "<cspace=0.025em><voffset=-6>o </voffset></cspace><color=#AAE0FA>o</color>";
                isBlue = true;
            }

            else if (l == 'b' || l == 'B')
            {
                mana_cost.text += "<cspace=0.025em><voffset=-6>o </voffset></cspace><color=#CBC2BF>o</color>";
                isBlack = true;
            }

            else if (l == 'r' || l == 'R')
            {
                mana_cost.text += "<cspace=0.025em><voffset=-6>o </voffset></cspace><color=#F9AA8F>o</color>";
                isRed = true;
            }

            else if (l == 'g' || l == 'G')
            {
                mana_cost.text += "<cspace=0.025em><voffset=-6>o </voffset></cspace><color=#9BD3AE>o</color>";
                isGreen = true;
            }

            else
            {
                mana_cost.text += "<cspace=0.025em><voffset=-6>o </voffset></cspace><color=#CBC2BF>o</color>";
            }

            mana_cost.text += l;
        }

        int c = 0;
        if(isWhite){
            c++;
        }
        if(isBlue){
            c++;
        }
        if(isBlack){
            c++;
        }
        if(isRed){
            c++;
        }
        if(isGreen){
            c++;
        }

        if(c > 1){
            isMulti = true;
        }else{
            isMulti = false;
        }
    }

    public void OracleTextConvert(){
        string oracleManaReplace = "";
        oracleManaReplace += gpt.oracle_text.Replace("{w}", "<font="+fonty+"><color=#FFFBD5>o</color><color=#000000>w</color></font>").Replace("{W}", "<font="+fonty+"><color=#FFFBD5>o</color><color=#000000>w</color></font>");
        oracleManaReplace = oracleManaReplace.Replace("{u}", "<font="+fonty+"><color=#AAE0FA>o</color><color=#000000>u</color></font>").Replace("{U}", "<font="+fonty+"><color=#AAE0FA>o</color><color=#000000>u</color></font>");
        oracleManaReplace = oracleManaReplace.Replace("{b}", "<font="+fonty+"><color=#CBC2BF>o</color><color=#000000>b</color></font>").Replace("{B}", "<font="+fonty+"><color=#CBC2BF>o</color><color=#000000>b</color></font>");
        oracleManaReplace = oracleManaReplace.Replace("{r}", "<font="+fonty+"><color=#F9AA8F>o</color><color=#000000>r</color></font>").Replace("{R}", "<font="+fonty+"><color=#F9AA8F>o</color><color=#000000>r</color></font>");
        oracleManaReplace = oracleManaReplace.Replace("{g}", "<font="+fonty+"><color=#9BD3AE>o</color><color=#000000>g</color></font>").Replace("{G}", "<font="+fonty+"><color=#9BD3AE>o</color><color=#000000>g</color></font>");

        oracleManaReplace = oracleManaReplace.Replace("{t}", "<font="+fonty+"><color=#CBC2BF>o</color><color=#000000>t</color></font>").Replace("{T}", "<font="+fonty+"><color=#CBC2BF>o</color><color=#000000>t</color></font>");
        oracleManaReplace = oracleManaReplace.Replace("{x}", "<font="+fonty+"><color=#CBC2BF>o</color><color=#000000>x</color></font>").Replace("{X}", "<font="+fonty+"><color=#CBC2BF>o</color><color=#000000>x</color></font>");
        oracleManaReplace = oracleManaReplace.Replace("{c}", "<font="+fonty+"><color=#CBC2BF>o</color><color=#000000>1</color></font>").Replace("{C}", "<font="+fonty+"><color=#CBC2BF>o</color><color=#000000>1</color></font>");

        for(int x = 0; x < 10; x++){
            oracleManaReplace = oracleManaReplace.Replace("{"+x+"}", "<font="+fonty+"><color=#CBC2BF>o</color><color=#000000>"+x+"</color></font>");
        }

        oracle_text.text = oracleManaReplace;
    }

    public void TitleColor(bool b){
        if(b){
            card_name.color = new Color(255,255,255,255);
        }else{
            card_name.color = new Color(0,0,0,255);
        }
    }
    public void TypeColor(bool b){
        if(b){
            type.color = new Color(255,255,255,255);
        }else{
            type.color = new Color(0,0,0,255);
        }
    }
    public void RuleColor(bool b){
        if(b){
            oracle_text.color = new Color(255,255,255,255);
        }else{
            oracle_text.color = new Color(0,0,0,255);
        }
    }
    public void PTColor(bool b){
        if(b){
            pt.color = new Color(255,255,255,255);
        }else{
            pt.color = new Color(0,0,0,255);
        }
    }
}
