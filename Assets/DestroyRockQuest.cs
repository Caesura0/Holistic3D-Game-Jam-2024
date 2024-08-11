using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRockQuest : Quest
{



    private void Start()
    {
        Player.OnTrashPickedUp += QuestRock_OnRockDestroyed;
    }

    private void QuestRock_OnRockDestroyed(int obj)
    {
        FinishQuest();
    }





}
