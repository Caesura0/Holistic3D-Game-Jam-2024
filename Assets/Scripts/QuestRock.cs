using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class QuestRock : Quest
{
    bool readyToMake;

    bool charcoalCollected;
    bool sulferCollected;

    private void Start()
    {
        Player.OnCharcolPickedUp += Player_OnCharcolPickedUp;
        Player.OnSulferPickedUp += Player_OnSulferPickedUp;
    }


    private void Player_OnSulferPickedUp(int obj)
    {
        sulferCollected = true;
        if (charcoalCollected)
        {
            readyToMake = true;
        }
    }

    private void Player_OnCharcolPickedUp(int obj)
    {
        charcoalCollected = true;
        if(sulferCollected)
        {
            readyToMake = true;
        }
    }

    
}
