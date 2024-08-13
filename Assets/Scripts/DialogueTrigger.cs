using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DialogueTrigger : MonoBehaviour, IInteractable
{

    [SerializeField] List<Dialogue> dialogueList;
    [SerializeField] List<Dialogue> questStartedDialogueList;

    [SerializeField] List<Dialogue> questCompleteDialogueList;
    [SerializeField] string conversantName;

    [SerializeField] ItemChest rewardChest;

    //[SerializeField] bool shouldRandomize;



    List<Dialogue> validDialogueList;

    Quest NPCQuest;
    bool questGiven = false;

    private void Start()
    {
        validDialogueList = new List<Dialogue>();
        NPCQuest = GetComponent<Quest>();
        NPCQuest.chest = rewardChest;
    }

    public string GetName()
    {
        return conversantName;
    }
    public void Interact(Player interactor)
    {

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
        
        if(NPCQuest != null && questCompleteDialogueList.Count > 0 && NPCQuest.GetQuestStatus() == QuestStatus.Finished)
        {
            return questCompleteDialogueList;
        }
        else if(NPCQuest != null && questStartedDialogueList.Count > 0 && NPCQuest.GetQuestStatus() == QuestStatus.Started)
        {
            return questStartedDialogueList;
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
            Debug.Log("quest inside");
            NPCQuest.StartQuest();
            questGiven = true;
            //QuestUIManager.Instance.AddQuest(NPCQuest);
        }

                


    }

}
