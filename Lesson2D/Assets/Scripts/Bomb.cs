using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float clickTime = 1.0f;
    int clicks = 10;
    Coroutine explodeCoroutine;
    Coroutine clickCoroutine;
    

    void StartExplodeCoroutine()
    {
        if (null != explodeCoroutine)
        {
            StopCoroutine(explodeCoroutine);
            StartCoroutine(Explode());
        }
        
        if (null == explodeCoroutine)
        {
            explodeCoroutine = StartCoroutine(Explode());
        }
    }
    
    void ExplodeBomb()
    {
        Destroy(gameObject);
    }

    IEnumerator Explode()
    {
        int clickCount = 0;
        float time;
        while (clickCount < clicks)
        {
            Click();
            clickCount++;
            time = Mathf.Lerp(clickTime, 0, 0.1f);
            yield return new WaitForSeconds(time);
        }
        ExplodeBomb();
    }

    void Click()
    {
        if (null != clickCoroutine)
        {
            StopCoroutine (clickCoroutine);
            StartCoroutine(ClickCoroutine());
        }

        if (null == clickCoroutine)
        {
            clickCoroutine = StartCoroutine(ClickCoroutine());
        }
    }

    IEnumerator ClickCoroutine()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.black;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartExplodeCoroutine();
    }
}
