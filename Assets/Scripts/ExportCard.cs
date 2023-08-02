using System.Collections;
using UnityEngine;
using System.IO;
using AnotherFileBrowser.Windows;

public class ExportCard : MonoBehaviour
{
    public RenderTexture rt;

    public void SaveCard()
    {
        var bp = new BrowserProperties();
        bp.filter = "Image files (*.png) | *.png";
        bp.filterIndex = 0;

        new FileBrowser().OpenSaveBrowser(bp, path =>
        {
            StartCoroutine(SaveImage(path));
        });
    }

    IEnumerator SaveImage(string path)
    {
        if (!path.Contains(".png"))
        {
            path += ".png";
        }

        // Wait for the end of the frame to ensure that the RenderTexture was completely drawn
        yield return new WaitForEndOfFrame();

        // Convert the RenderTexture to a Texture2D
        Texture2D texture = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
        RenderTexture.active = rt;
        texture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        texture.Apply();
        RenderTexture.active = null;

        // Convert the Texture2D to a .png format
        byte[] pngData = texture.EncodeToPNG();

        // Save the png data to a file
        if (pngData != null)
        {
            File.WriteAllBytes(path, pngData);
        }
        else
        {
            Debug.LogError("Failed to convert Texture2D to PNG.");
        }
    }
}
