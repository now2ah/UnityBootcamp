using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeImage;
    public Text endCountText;
    Coroutine fadeInCoroutine;
    Coroutine fadeOutCoroutine;
    [SerializeField]
    float fadeTime = 0.01f;
    [SerializeField]
    int endCount = 5;

    public void StartFadeInCoroutine()
    {
        if (null != fadeInCoroutine)
        {
            StopCoroutine(fadeInCoroutine);
            StartCoroutine(FadeIn());
        }
        
        if (null == fadeInCoroutine)
        {
            fadeInCoroutine = StartCoroutine(FadeIn());
        }
    }

    public void StartFadeOutCoroutine()
    {
        if (null != fadeOutCoroutine)
        {
            StopCoroutine(fadeOutCoroutine);
            StartCoroutine(FadeOut());
        }
        
        if (null == fadeOutCoroutine)
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
                float nextAlpha = fadeImage.color.a - fadeTime;
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, nextAlpha);
                yield return null;
            }
        }
    }

    IEnumerator FadeOut()
    {
        if (null != fadeImage)
        {
            while (fadeImage.color.a < 1)
            {
                float nextAlpha = fadeImage.color.a + fadeTime;
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, nextAlpha);
                yield return null;
            }
        }
    }

    IEnumerator EndSceneCoroutine()
    {
        if (null != endCountText)
        {
            while (endCount > 0)
            {
                endCount--;
                endCountText.text = endCount.ToString();
                yield return new WaitForSeconds(1.0f);
            }

            StartFadeOutCoroutine();
        }
    }

    void Start()
    {
        StartFadeInCoroutine();
        StartCoroutine("EndSceneCoroutine");
    }
}
