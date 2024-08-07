using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickupItem : MonoBehaviour , IInteractable
{

    [SerializeField] Item itemStruct;
    [SerializeField] int quantity = 1;
    //[SerializeField] int quantity;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemStruct.itemSprite;
    }

    public void Interact(Player player)
    {
        player.AddItem(itemStruct, quantity);
        Destroy(gameObject);
        //playsound;
    }
}

public enum ItemType
{
    Bottle,
    Hoe,
    PickAxe,
    Ax,
    WateringCan,
    Seed

}

[System.Serializable]
public struct Item
{
    public string itemName;
    public Sprite itemSprite;
    public ItemType itemType;
}
