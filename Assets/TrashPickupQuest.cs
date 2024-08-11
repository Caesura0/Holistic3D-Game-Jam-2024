using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickupQuest : Quest
{

    int trashPickedUp;
    int trashAssigned = 3;


    private void Start()
    {
        Player.OnTrashPickedUp += Player_OnTrashPickedUp;
    }

    private void Player_OnTrashPickedUp(int obj)
    {
        trashPickedUp++;
        if(trashPickedUp == trashAssigned)
        {
            FinishQuest();
        }
    }





}
