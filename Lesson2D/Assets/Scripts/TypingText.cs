using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour
{
    public Text message;
    public Button progressButton;
    [SerializeField][TextArea]
    string content;
    [SerializeField]
    float delay = 0.3f;
    bool isMessaging = false;


    public void OnMessageButtonClicked()
    {
        if (!isMessaging)
        {
            StartCoroutine("TypingCoroutine");
        }
            
    }

    public void ByTwo()
    {
        if (delay == 0.1f)
            delay = 0.3f;
        else
            delay = 0.1f;
    }

    IEnumerator TypingCoroutine()
    {
        isMessaging = true;
        progressButton.interactable = false;

        message.text = "";

        int typingCount = 0;

        while (typingCount != content.Length)
        {
            if (typingCount < content.Length)
            {
                message.text += content[typingCount];
                typingCount++;
            }

            yield return new WaitForSeconds(delay);
        }

        progressButton.interactable = true;
        isMessaging = false;
    }
}
