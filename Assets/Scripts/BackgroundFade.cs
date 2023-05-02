using System.Collections;
using UnityEngine;

public class BackgroundFade : MonoBehaviour
{
    public Sprite[] backgroundSprites;
    public float timeFade = 60f;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = backgroundSprites[0];
        StartCoroutine(FadeBetweenSprites());
    }

    IEnumerator FadeBetweenSprites()
    {
        int currentSpriteIndex = 0;

        while (true)
        {
            // Fade out the current sprite
            for (float alpha = 1f; alpha >= 0; alpha -= Time.deltaTime)
            {
                Color spriteColor = GetComponent<SpriteRenderer>().color;
                spriteColor.a = alpha;
                GetComponent<SpriteRenderer>().color = spriteColor;
                yield return null;
            }

            // Switch to the next sprite
            currentSpriteIndex = (currentSpriteIndex + 1) % backgroundSprites.Length;
            GetComponent<SpriteRenderer>().sprite = backgroundSprites[currentSpriteIndex];

            // Fade in the new sprite
            for (float alpha = 0f; alpha <= 1f; alpha += Time.deltaTime)
            {
                Color spriteColor = GetComponent<SpriteRenderer>().color;
                spriteColor.a = alpha;
                GetComponent<SpriteRenderer>().color = spriteColor;
                yield return null;
            }

            // Wait for one minute
            yield return new WaitForSeconds(timeFade);
        }
    }
}