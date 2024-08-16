using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DialogueTrigger : MonoBehaviour, IInteractable
{

    [SerializeField] List<Dialogue> dialogueList;
    [SerializeField] List<Dialogue> questStartedDialogueList;

    [SerializeField] List<Dialogue> questCompleteDialogueList;


    [SerializeField] List<Dialogue> finalAlchemistSpeak;
    [SerializeField] string conversantName;

    [SerializeField] ItemChest rewardChest;
    [SerializeField] ItemChest questStartChest;

    [SerializeField] bool finishQuestByTalking;
    [SerializeField] bool isAlchemist;

    //[SerializeField] bool shouldRandomize;



    List<Dialogue> validDialogueList;

    Quest NPCQuest;
    bool questGiven = false;
    bool rewardGiven = false;

    bool blownup = false;
    private void Start()
    {
        validDialogueList = new List<Dialogue>();
        NPCQuest = GetComponent<Quest>();
        if (rewardChest != null)
        {
            NPCQuest.chest = rewardChest;
        }
    }

    public string GetName()
    {
        return conversantName;
    }
    public void Interact(Player interactor)
    {
        if(NPCQuest != null)
        {
            NPCQuest.AssignPlayer(interactor);
        }

        foreach (Dialogue dialogue in GetDialogueToSay())
        {
            if (!dialogue.hasSaidDialogue)
            {
                SimpleDialogueManager.Instance.StartDialogue(dialogue, this);
                return;
            }
            else if (dialogue.isRepeatableDialogue)
            {
                validDialogueList.Add(dialogue);
            }
        }


        if (validDialogueList.Count > 0)
        {
            int choices;
            choices = validDialogueList.Count - 1;
            int i = Random.Range(0, choices);
            SimpleDialogueManager.Instance.StartDialogue(validDialogueList[i], this) ;
        }
        else
        {
            SimpleDialogueManager.Instance.StartDialogue(null, this);
        }


    }

    public List<Dialogue> GetDialogueToSay()
    {
        if (finishQuestByTalking && !blownup)
        {
            NPCQuest.CheckQuestIsFinished();
        }

        if (NPCQuest != null && questCompleteDialogueList.Count > 0 && NPCQuest.GetQuestStatus() == QuestStatus.Finished && !blownup)
        {
            
            return questCompleteDialogueList;
        }
        else if(NPCQuest != null && questStartedDialogueList.Count > 0 && NPCQuest.GetQuestStatus() == QuestStatus.Started)
        {
            return questStartedDialogueList;
        }

        else if( isAlchemist && NPCQuest.GetQuestStatus() == QuestStatus.Finished && blownup)
        {
            return finalAlchemistSpeak;
        }
        else
        {
            return dialogueList;
        }
    }
    public void OnDialogueEnd()
    {
        Debug.Log(NPCQuest.GetQuestName());
        if (NPCQuest != null && !questGiven)
        {
            if(questStartChest != null)
            {
                questStartChest.UnlockChest();
                questStartChest.ShakeChest();
            }
    
            NPCQuest.StartQuest();
            questGiven = true;
            
            //QuestUIManager.Instance.AddQuest(NPCQuest);
        }

        if (NPCQuest != null && NPCQuest.questStatus == QuestStatus.Started && questStartChest != null)
        {
            questStartChest.ShakeChest();
        }

        if (NPCQuest != null && NPCQuest.questStatus == QuestStatus.Finished)
        {
            if (isAlchemist && !blownup)
            {
                blownup = true;
                    NPCQuest.BlowUpRock();
  
            }
            if (questStartChest != null)
            {
                rewardChest.ShakeChest();
            }
        }






    }

}
