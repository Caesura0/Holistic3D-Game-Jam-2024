using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSaveVillage : Quest
{
    [SerializeField] GameObject rocks;


    private void Update()
    {

        if(questStatus == QuestStatus.Finished && !SimpleDialogueManager.Instance.InDialogue)
        {
            Debug.Log("saved");
            StartCoroutine(SceneFadeTransition.Instance.FadeInSceneGameEnd(1));
        }
    }
    public override void CheckQuestIsFinished()
    {
        Debug.Log(rocks.activeSelf);
        if(rocks.activeSelf == false)
        {  
            base.CheckQuestIsFinished();
            FinishQuest();
        }  
    }
}
