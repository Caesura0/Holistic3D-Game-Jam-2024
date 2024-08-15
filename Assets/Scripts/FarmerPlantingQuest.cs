using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerPlantingQuest : Quest
{
    int farmPlotsNeeded = 16;
    int farmPlots ;

    private void OnEnable()
    {
        FarmableSoil.OnAnyTilePlantedAndWatered += FarmableSoil_OnAnyTilePlantedAndWatered;
    }

    private void FarmableSoil_OnAnyTilePlantedAndWatered()
    {
        farmPlots++;
        if(farmPlots >= farmPlotsNeeded)
        {
            FinishQuest();
        }
    }

    private void OnDisable()
    {
        FarmableSoil.OnAnyTilePlantedAndWatered -= FarmableSoil_OnAnyTilePlantedAndWatered;
    }
}
