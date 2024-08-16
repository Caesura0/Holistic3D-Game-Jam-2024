using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCharcoalBurner : Quest
{

    bool rewardGiven;
    int woodPickedUp;
    int woodAssigned = 5;
    private void Start()

    {
        Player.OnWoodPickedUp += Player_OnTrashPickedUp;
    }

    private void Player_OnTrashPickedUp(int obj)
    {
        woodPickedUp++;
        SoundManager.Instance.PlayItemPickupSound();

        //if (woodPickedUp >= woodAssigned && questStatus == QuestStatus.Started)
        //{
        //    FinishQuest();
        //}
    }

    public override void CheckQuestIsFinished()
    {
        if (woodPickedUp >= woodAssigned && !rewardGiven)
        {
            
            player.CharcolPickup();
            FinishQuest();
        }
        base.CheckQuestIsFinished();
    }

    public override void FinishQuest()
    {
        rewardGiven = true;
        base.FinishQuest();
    }

    public override void StartQuest()
    {
        //if (woodPickedUp >= woodAssigned)
        //{
        //    FinishQuest();
        //}
        base.StartQuest();
    }
}
