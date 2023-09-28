using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;

    private void Awake()
    {
        // Ensure the fade panel is transparent at start
        Color c = fadePanel.color;
        c.a = 0f;
        fadePanel.color = c;
    }

    public IEnumerator FadeOut()
    {
        float fadeSpeed = 1 / fadeDuration;
        Color c = fadePanel.color;

        while (c.a < 1)
        {
            c.a += fadeSpeed * Time.deltaTime;
            fadePanel.color = c;
            yield return null;
        }
    }

    public IEnumerator FadeIn()
    {
        float fadeSpeed = 1 / fadeDuration;
        Color c = fadePanel.color;

        while (c.a > 0)
        {
            c.a -= fadeSpeed * Time.deltaTime;
            fadePanel.color = c;
            yield return null;
        }
    }
}