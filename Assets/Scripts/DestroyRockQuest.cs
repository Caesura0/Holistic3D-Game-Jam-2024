using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRockQuest : Quest
{
    //on chemist quest complete

    [SerializeField] GameObject largeBoulder;
    [SerializeField] GameObject riverTilemap;

    int charcoal;
    int sulfer;


    private void Start()
    {
        Player.OnSulferPickedUp += Player_OnSulferPickedUp;      
        Player.OnCharcolPickedUp += Player_OnCharcoalPickedUp;
    }



    void Player_OnSulferPickedUp(int sulfer)
    {
        this.sulfer++;
    }

    void Player_OnCharcoalPickedUp( int charcoal)
    {
        Debug.Log("charcol");
        this.charcoal++;
    }

    public override void CheckQuestIsFinished()
    {

        if (charcoal >= 1 && sulfer >= 4)
        {

            largeBoulder.SetActive(false);
            riverTilemap.SetActive(true);
            FinishQuest();
            base.CheckQuestIsFinished();
        }
    }
    






}
