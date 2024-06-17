using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ExportCard : MonoBehaviour
{
    public TextMeshProUGUI collectorsID;
    public int currentCard;
    public int totalCard;

    public RenderTexture cardOutput;

    public void SaveCard(){
        Texture2D card = new Texture2D(cardOutput.width, cardOutput.height, TextureFormat.RGBAHalf, false);
        RenderTexture.active = cardOutput;
        card.ReadPixels(new Rect(0, 0, cardOutput.width, cardOutput.height), 0, 0);
        RenderTexture.active = null;

        byte[] bytes = card.EncodeToPNG();
        string filePath = Application.dataPath + "/" + currentCard + "_" + totalCard + ".png";
        File.WriteAllBytes(filePath, bytes);

        currentCard++;
    }

    void Update(){
        collectorsID.text = currentCard.ToString() + "/" + totalCard.ToString();
    }
}
