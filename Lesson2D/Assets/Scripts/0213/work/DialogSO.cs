using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Dialog", menuName = "ScriptableObject/Dialog")]
public class DialogSO : ScriptableObject
{
    public List<Dialog> dialogs;
}
