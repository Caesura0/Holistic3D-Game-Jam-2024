using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleDialogueManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI conversantName;

    [SerializeField] float textSpeed;



    [SerializeField] Dialogue defaultDialogue;

    Dialogue currentDialogue;
    DialogueTrigger conversant;

    int index = 1;

    public bool InDialogue { get; private set; }

    


    public static SimpleDialogueManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        gameObject.SetActive(false);
    }

    private void Start()
    {
        PlayerInput.Instance.OnInteractAction += PlayerInput_OnInteractAction;
    }

    private void PlayerInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (currentDialogue != null)
        {
            if (dialogueText.text == currentDialogue.dialogueLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = currentDialogue.dialogueLines[index];
            }
        }
    }

    void Update()
    {


    }


    public void StartDialogue(Dialogue dialogue, DialogueTrigger conversant)
    {
        InDialogue = true;
        this.conversant = conversant;

        gameObject.SetActive(true);
        index = 0;
        dialogueText.text = string.Empty;
        if (dialogue != null)
        {
            currentDialogue = dialogue;
        }
        else
        {
            currentDialogue = defaultDialogue;
        }

        conversantName.text = conversant.GetName();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentDialogue.dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < currentDialogue.dialogueLines.Count - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            conversant.OnDialogueEnd();
            currentDialogue = null;
            InDialogue = false;
            gameObject.SetActive(false);
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
