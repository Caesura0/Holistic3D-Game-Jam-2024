using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SulferCollectedUI : MonoBehaviour
{
    TextMeshProUGUI uiText;

    private void Awake()
    {
        uiText = GetComponentInChildren<TextMeshProUGUI>();
        uiText.text = "Sulfur : ";
    }

    private void OnEnable()
    {
        Player.OnSulferPickedUp += UpdateTrashUI;
    }
    private void OnDisable()
    {
        Player.OnSulferPickedUp -= UpdateTrashUI;
    }

    private void UpdateTrashUI(int trash)
    {
        uiText.text = "Sulfur : " + trash.ToString();
    }
}
