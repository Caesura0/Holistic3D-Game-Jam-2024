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
    public class QuestChangedEventArgs : EventArgs
    {
        public string QuestName { get; }
        public string QuestStatus { get; }

        public QuestChangedEventArgs(string QuestName, string QuestStatus)
        {
            this.QuestName = QuestName;
            this.QuestStatus = QuestStatus;
        }
    }

    public Player player;

    public event EventHandler OnAnyQuestFinished;
    public event EventHandler OnAnyQuestStarted;


    public static event EventHandler<QuestChangedEventArgs> OnAnyQuestChanged;



    [SerializeField] protected string questName;
    [SerializeField] public QuestStatus questStatus;

    public ItemChest chest;


    public virtual string GetQuestName()
    {
        return questName;
    }

    public virtual void CheckQuestIsFinished()
    {
        
    }

    public void AssignPlayer(Player player)
    {
        this.player = player;
    }
    public virtual void StartQuest()
    {
        questStatus = QuestStatus.Started;
        OnAnyQuestStarted?.Invoke(this, EventArgs.Empty);
        OnAnyQuestChanged?.Invoke(this, new QuestChangedEventArgs(questName, questStatus.ToString()));
        QuestUIManager.Instance.AddQuest(this);
        SoundManager.Instance.PlayQuestStartedSound();
    }

    public virtual void FinishQuest()
    {
        questStatus = QuestStatus.Finished;
        OnAnyQuestFinished?.Invoke(this, EventArgs.Empty);
        OnAnyQuestChanged?.Invoke(this, new QuestChangedEventArgs(questName, questStatus.ToString()));
        QuestUIManager.Instance.RedrawQuestList();
        if (chest != null)
        {
            chest.UnlockChest();
        }

        SoundManager.Instance.PlayQuestFinishedSound();
        
    }
    public virtual QuestStatus GetQuestStatus()
    {
        return questStatus;
    }
}
