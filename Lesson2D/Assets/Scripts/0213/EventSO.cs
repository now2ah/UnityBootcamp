using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class EventSO : ScriptableObject
{
    public event Action<string> OnEvent;

    public void DoInvoke(string somethingString)
    {
        if (null != OnEvent)
            OnEvent.Invoke(somethingString);
    }
}
