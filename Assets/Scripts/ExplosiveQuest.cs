using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveQuest : Quest
{

    int sulferPickedup;
    int sulferNeeded = 5;

    int charcolNeeded = 10;
    int charcolPickedup;




    private void Start()
    {
        //Player.OnTrashPickedUp += Player_OnTrashPickedUp;
    }

    private void Player_OnCharcolPickedUp(int obj)
    {
        CheckIfQuestFinished();
    }

    private void Player_OnSulferPickedUp(int obj)
    {
        CheckIfQuestFinished();
    }

    private void CheckIfQuestFinished()
    {
        if (charcolPickedup == charcolNeeded && sulferNeeded == sulferPickedup)
        {
            FinishQuest();
        }
    }
}
