using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{

    [SerializeField] List<Dialogue> dialogueList;
    [SerializeField] string conversantName;

    //[SerializeField] bool shouldRandomize;



    List<Dialogue> validDialogueList;


    private void Start()
    {
        validDialogueList = new List<Dialogue>();
    }

    public void Interact(Player interactor)
    {

        foreach (Dialogue dialogue in dialogueList)
        {
            if (!dialogue.hasSaidDialogue)
            {
                SimpleDialogueManager.Instance.StartDialogue(dialogue, conversantName);
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
            SimpleDialogueManager.Instance.StartDialogue(validDialogueList[i], conversantName);
        }
        else
        {
            SimpleDialogueManager.Instance.StartDialogue(null, conversantName);
        }


    }


}
