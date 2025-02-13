using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using NUnit.Framework;
using System.Collections;

public class UISystem : MonoBehaviour
{
    public Button startButton;
    public GameObject dialogPanel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentText;
    public event EventHandler OnStartDialog;

    Coroutine dialogCoroutine;

    public void LoadSingleDialog(string speaker, string content)
    {
        if (null != nameText && null != contentText)
        {
            nameText.text = speaker;
            //contentText.text = content;
            contentText.text = "";
            _StartDialogCoroutine(content);
        }
    }

    public void EndDialog()
    {
        dialogPanel.SetActive(false);
    }

    void _OnStart(object sender, EventArgs e)
    {
        if (null != dialogPanel)
        {
            startButton.gameObject.SetActive(false);
            dialogPanel.gameObject.SetActive(true);
        }
    }

    void _StartDialogEvent()
    {
        if (null != OnStartDialog)
            OnStartDialog.Invoke(this, EventArgs.Empty);
    }

    void _StartDialogCoroutine(string content)
    {
        if (null != dialogCoroutine)
            StopCoroutine(dialogCoroutine);

        dialogCoroutine = StartCoroutine(DialogCoroutine(content));
    }

    IEnumerator DialogCoroutine(string content)
    {
        foreach(var c in content)
        {
            contentText.text += c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(_StartDialogEvent);
        OnStartDialog += _OnStart;
    }
}
