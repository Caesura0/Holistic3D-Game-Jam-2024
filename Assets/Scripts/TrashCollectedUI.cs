using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TrashCollectedUI : MonoBehaviour
{
    TextMeshProUGUI uiText;

    private void Awake()
    {
        uiText = GetComponentInChildren<TextMeshProUGUI>();
        uiText.text = "Trash Collected : ";
    }

    private void OnEnable()
    {
        Player.OnTrashPickedUp += UpdateTrashUI;
    }
    private void OnDisable()
    {
        Player.OnTrashPickedUp -= UpdateTrashUI;
    }

    private void UpdateTrashUI(int trash)
    {
        uiText.text = "Trash Collected : " + trash.ToString();
    }
}
