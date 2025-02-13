using System;
using TMPro;
using UnityEngine;

public class QuestViewer : MonoBehaviour
{
    public TextMeshProUGUI questTitleText;
    public TextMeshProUGUI questDescText;
    public TextMeshProUGUI questGoalText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI expText;
    public Quest quest;
    public Cat cat;

    void _OnStartQuest(object o, EventArgs e)
    {
        questTitleText.text = quest.questTitle;
        questDescText.text = quest.questDesc;
        questGoalText.text = "(" + quest.questRequirement.itemCount + " / " + quest.questRequirement.gatherItemCount + ")";

        questTitleText.gameObject.SetActive(true);
        questDescText.gameObject.SetActive(true);
        questGoalText.gameObject.SetActive(true);
    }

    void _UpdateValues(object o, EventArgs e)
    {
        questGoalText.text = "(" + quest.questRequirement.itemCount + " / " + quest.questRequirement.gatherItemCount + ")";
    }

    void _OnDoneQuest(object o, EventArgs e)
    {
        questTitleText.gameObject.SetActive(false);
        questDescText.gameObject.SetActive(false);
        questGoalText.gameObject.SetActive(false);
    }

    void _OnValueChange(object o, EventArgs e)
    {
        goldText.text = "Gold : " + cat.Gold;
        expText.text = "Exp : " + cat.Exp;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quest.OnStartQuest += _OnStartQuest;
        quest.OnProgressQuest += _UpdateValues;
        quest.OnDoneQuest += _OnDoneQuest;
        cat.OnValueChange += _OnValueChange;
    }
}
