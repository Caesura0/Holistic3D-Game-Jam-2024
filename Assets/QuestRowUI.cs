using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestRowUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questNameUI;
    [SerializeField] TextMeshProUGUI questStatusUI;

    public void SetUIText(string questName, string questStatus)
    {
        questNameUI.text = questName;
        questStatusUI.text = "  :  " + questStatus;
    }
}
