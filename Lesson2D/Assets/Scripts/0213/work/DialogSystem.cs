using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Dialog
{
    [SerializeField]
    public string speaker;
    [SerializeField]
    public string content;
}

public class DialogSystem : MonoBehaviour
{
    public DialogSO dialogSO;
    public UISystem uiSystem;

    Queue<Dialog> dialogQueue;

    void _LoadDialog(object sender, EventArgs e)
    {
        if (null != dialogSO && null != uiSystem)
        {
            dialogQueue = new Queue<Dialog>();
            foreach(var dialog in dialogSO.dialogs)
            {
                dialogQueue.Enqueue(dialog);
            }

            Dialog nextDialog = dialogQueue.Dequeue();
            uiSystem.LoadSingleDialog(nextDialog.speaker, nextDialog.content);
        }
    }

    void _ProcessDialog()
    {
        if (dialogQueue.Count > 0)
        {
            Dialog nextDialog = dialogQueue.Dequeue();
            uiSystem.LoadSingleDialog(nextDialog.speaker, nextDialog.content);
        }
        else
        {
            uiSystem.EndDialog();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (null != uiSystem)
        {
            uiSystem.OnStartDialog += _LoadDialog;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ProcessDialog();
        }
    }
}
