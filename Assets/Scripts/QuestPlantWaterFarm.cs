using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPlantWaterFarm : Quest
{
    int soilCompleted;
    int soilNeeded = 12;

    private void Start()
    {
        FarmableSoil.OnAnyTilePlantedAndWatered += FarmableSoil_OnAnyTilePlantedAndWatered;
    }

    private void FarmableSoil_OnAnyTilePlantedAndWatered()
    {
        soilCompleted++;
        CheckQuestCompletion();
    }

    public void CheckQuestCompletion()
    {
        if (soilCompleted >= soilNeeded && questStatus == QuestStatus.Started)
        {
            //player.CharcolPickup();
            //player.CharcolPickup();
            //player.CharcolPickup();
            FinishQuest();
        }
    }
}
