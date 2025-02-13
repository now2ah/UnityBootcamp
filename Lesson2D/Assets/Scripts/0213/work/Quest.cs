using System;
using UnityEngine;

public enum eQuestType
{
    NONE,
    ONCE,
    REPEAT
}

public enum eQuestState
{
    NOTSTARTED,
    STARTED,
    END
}

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObject/Quest")]
public class Quest : ScriptableObject
{
    public eQuestType questType;
    public eQuestState questState;
    public QuestReward questReward;
    public QuestRequirement questRequirement;
    public event EventHandler OnStartQuest;
    public event EventHandler OnProgressQuest;
    public event EventHandler OnDoneQuest;

    [Header("Quest Info")]
    public string questTitle;
    [TextArea]
    public string questDesc;

    public void StartQuest()
    {
        OnStartQuest.Invoke(this, EventArgs.Empty);
    }

    public void ProgressQuest()
    {
        if (questRequirement.itemCount < questRequirement.gatherItemCount)
        {
            questRequirement.itemCount++;
            OnProgressQuest.Invoke(this, EventArgs.Empty);
        }
        
        if (questRequirement.itemCount == questRequirement.gatherItemCount)
        {
            OnDoneQuest.Invoke(this, EventArgs.Empty);
        }
    }
}

[CreateAssetMenu(fileName = "Requirement", menuName = "ScriptableObject/Requirement")]
public class QuestRequirement : ScriptableObject
{
    public int gatherItemCount;
    public int itemCount;
}

[CreateAssetMenu(fileName = "Reward", menuName = "ScriptableObject/Reward")]
public class QuestReward : ScriptableObject
{
    public int gold;
    public int exp;
}
