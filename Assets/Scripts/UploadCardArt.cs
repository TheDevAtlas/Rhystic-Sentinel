using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using AnotherFileBrowser.Windows;
using UnityEngine.Networking;

public class UploadCardArt : MonoBehaviour
{
    string path;
    public RawImage image;
    public Texture2D target;

    public void OpenExplorer()
    {
        /*path = EditorUtility.OpenFilePanel("Import Art", "", "png");
        if (!string.IsNullOrEmpty(path))
        {
            GetImage();
        }*/

        var bp = new BrowserProperties();
        bp.filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            //Load image from local path with UWR
            StartCoroutine(LoadImage(path));
        });
    }

    IEnumerator LoadImage(string path)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                image.texture = uwrTexture;
                // Calculate the new width and height to fit within 100 pixels
                int originalWidth = uwrTexture.width;
                int originalHeight = uwrTexture.height;
                int maxDimension = 100;

                float aspectRatio = (float)originalWidth / originalHeight;
                int newWidth, newHeight;

                if (aspectRatio >= 1)
                {
                    newWidth = maxDimension;
                    newHeight = Mathf.RoundToInt(maxDimension / aspectRatio);
                }
                else
                {
                    newHeight = maxDimension;
                    newWidth = Mathf.RoundToInt(maxDimension * aspectRatio);
                }
                // Resize Image To Normal People Size - Fixes Small and Large Images //
                image.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(newWidth, newHeight);
            }
        }
    }
}
