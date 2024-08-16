using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CharcoalCollectedUI : MonoBehaviour
{
    TextMeshProUGUI uiText;

    private void Awake()
    {
        uiText = GetComponentInChildren<TextMeshProUGUI>();
        uiText.text = "Charcoal : ";
    }

    private void OnEnable()
    {
        Player.OnCharcolPickedUp += UpdateTrashUI;
    }
    private void OnDisable()
    {
        Player.OnCharcolPickedUp -= UpdateTrashUI;
    }

    private void UpdateTrashUI(int trash)
    {
        uiText.text = "Charcoal : " + trash.ToString();
    }
}
