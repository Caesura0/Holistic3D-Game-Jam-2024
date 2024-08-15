using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMilkCows : Quest
{

    int milkNeeded = 5;

    [SerializeField] Item milkItem;

    public override void CheckQuestIsFinished()
    {
        base.CheckQuestIsFinished();
        if (InventoryManager.Instance.CountCurrentMilk() >= milkNeeded)
        {
            InventoryManager.Instance.RemoveItem(milkItem, milkNeeded);
            FinishQuest();
        }

    }
}
