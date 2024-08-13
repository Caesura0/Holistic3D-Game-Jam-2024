using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum QuestStatus
{
    None,
    Started,
    Finished,
}
public abstract class Quest : MonoBehaviour
{

    public event EventHandler OnAnyQuestFinished;
    public event EventHandler OnAnyQuestStarted;

    [SerializeField] protected string questName;
    [SerializeField] public QuestStatus questStatus;

    public ItemChest chest;


    public virtual string GetQuestName()
    {
        return questName;
    }

    public virtual void StartQuest()
    {
        questStatus = QuestStatus.Started;
        OnAnyQuestStarted?.Invoke(this, EventArgs.Empty);
        QuestUIManager.Instance.AddQuest(this);
    }

    public virtual void FinishQuest()
    {
        questStatus = QuestStatus.Finished;
        OnAnyQuestFinished?.Invoke(this, EventArgs.Empty);
        QuestUIManager.Instance.RedrawQuestList();
        chest.UnlockChest(); 
    }
    public virtual QuestStatus GetQuestStatus()
    {
        return questStatus;
    }
}
