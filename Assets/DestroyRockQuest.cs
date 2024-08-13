using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRockQuest : Quest
{
    //on chemist quest complete

    [SerializeField] GameObject largeBoulder;
    [SerializeField] GameObject riverTilemap;
    private void Start()
    {
        //Player.OnTrashPickedUp += QuestRock_OnRockDestroyed;
    }

    private void QuestRock_OnRockDestroyed(int obj)
    {
        largeBoulder.SetActive(false);
        riverTilemap.SetActive(true);
        FinishQuest();
    }





}
