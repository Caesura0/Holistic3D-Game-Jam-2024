using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIManager : MonoBehaviour
{
    public static QuestUIManager Instance;

    [SerializeField] GameObject questUIRowPrefab;


    [SerializeField] GameObject questContentWindow;
    [SerializeField] GameObject QuestUIHolder;

    List<Quest> questlist = new List<Quest>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        QuestUIHolder.SetActive(false);
        PlayerInput.Instance.OnQuestUIAction += PlayerInput_OnQuestUIAction;
    }

    private void PlayerInput_OnQuestUIAction(object sender, System.EventArgs e)
    {
        OpenCloseUI();
    }

    public void AddQuest(Quest quest)
    {
        questlist.Add(quest);
        RedrawQuestList();
    }
    

    public void RedrawQuestList()
    {
        DestroyAllChildren();
        //inventoryUISlotList.Clear();
        foreach (Quest quest in questlist)
        {
            Debug.Log(quest.GetQuestName());
            var questUIRow = Instantiate(questUIRowPrefab, questContentWindow.transform);
            Debug.Log(questUIRow);
            questUIRow.GetComponent<QuestRowUI>().SetUIText(quest.GetQuestName(), quest.GetQuestStatus().ToString());
        }
    }

    public void OpenCloseUI()
    {

        bool isActive = QuestUIHolder.activeSelf;
        QuestUIHolder.SetActive(!isActive);

    }

    public void DestroyAllChildren()
    {
        // Loop through all child objects
        foreach (Transform child in questContentWindow.transform)
        {
            // Destroy each child GameObject
            Destroy(child.gameObject);
        }
    }
}
