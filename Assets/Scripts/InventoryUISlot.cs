using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUISlot : MonoBehaviour
{

    [SerializeField] Image icon;
    [SerializeField] GameObject highLight;
    [SerializeField] TextMeshProUGUI number;

    Item item;
    int count;
    private void Start()
    {
        UpdateSelectedVisual(false);
    }

    public void UpdateUI(Item item, int count)
    {
        this.item = item;
        icon.sprite = item.itemSprite;
        this.count = count;
        if (count > 1) { number.text = count.ToString(); }
        else { number.text = ""; }


    }

    public Item GetItemInSlot( out int count)
    {
        count = this.count;
        return item;
    }
    public void UpdateSelectedVisual(bool selected)
    {
        highLight.gameObject.SetActive(selected);
    }


}
