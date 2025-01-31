using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextCount : MonoBehaviour
{
    public Text countText;
    int count = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("CountPlus");
    }

    IEnumerator CountPlus()
    {
        while(true)
        {
            count++;
            countText.text = count.ToString("N0");
            yield return new WaitForSeconds(1f);
        }
    }
}
