using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeImage;
    Coroutine fadeInCoroutine;
    Coroutine fadeOutCoroutine;
    float fadeTime = 0.1f;

    void StartFadeInCoroutine()
    {
        if (null != fadeInCoroutine)
        {
            StopCoroutine(fadeInCoroutine);
        }
        else if (null == fadeInCoroutine)
        {
            fadeInCoroutine = StartCoroutine(FadeIn());
        }
    }

    void StartFadeOutCoroutine()
    {
        if (null != fadeOutCoroutine)
        {
            StopCoroutine(fadeOutCoroutine);
        }
        else if (null == fadeOutCoroutine)
        {
            fadeOutCoroutine = StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        if (null != fadeImage)
        {
            while (fadeImage.color.a > 0)
            {
                float nextAlpha = fadeImage.color.a;
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, nextAlpha--);
                yield return new WaitForSeconds(fadeTime);
            }
        }
    }

    IEnumerator FadeOut()
    {
        if (null != fadeImage)
        {
            while (fadeImage.color.a < 1)
            {
                float nextAlpha = fadeImage.color.a;
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, nextAlpha++);
                yield return new WaitForSeconds(fadeTime);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartFadeInCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
