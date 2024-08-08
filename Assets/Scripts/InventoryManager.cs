using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;


    Dictionary<Item, int> itemList = new Dictionary<Item, int>();

    [SerializeField] GameObject inventoryUISlotPrefab;

    List<InventoryUISlot> inventoryUISlotList = new List<InventoryUISlot>();

    int selectedInventoryIndex = 0;

 
        
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        RedrawUI();
    }

    public void SelectUISlot(int index)
    {
        if (inventoryUISlotList.Count > index)
        {
            inventoryUISlotList[selectedInventoryIndex].UpdateSelectedVisual(false);
            selectedInventoryIndex = index;

            inventoryUISlotList[index].UpdateSelectedVisual(true); ;
        }
    }

    public bool ContainsItem(ItemType type)
    {
        foreach(Item item in itemList.Keys)
        {
            if(item.itemType == type) return true;
        }
        return false;
    }

    public Item? GetSelectedItem()
    {
        if (inventoryUISlotList.Count == 0) return null;
        return inventoryUISlotList[selectedInventoryIndex].GetItemInSlot(out int count);
    }

    void RedrawUI()
    {
        DestroyAllChildren();
        inventoryUISlotList.Clear();

        foreach (var item in itemList)
        {
            var itemSlotGO = Instantiate(inventoryUISlotPrefab.gameObject, this.transform);
            var itemSlot = itemSlotGO.GetComponent<InventoryUISlot>();
            Debug.Log(itemSlot);
            itemSlot.UpdateUI(item.Key, item.Value);
            inventoryUISlotList.Add(itemSlot);
        }

        
    }


    public void AddItem(Item item, int quantity)
    {

        if (itemList.ContainsKey(item))
        {
            itemList[item] += quantity;
        }
        else
        {
            itemList[item] = quantity;
        }
        RedrawUI();
    }

    public void RemoveItem(Item item, int quantity)
    {
        if (itemList.ContainsKey(item))
        {
            itemList[item] -= quantity;

            if (itemList[item] <= 0)
            {
                itemList.Remove(item);
            }
        }
        RedrawUI();
    }


    public int GetQuantity(Item item)
    {
        return itemList.ContainsKey(item) ? itemList[item] : 0;
    }
    public void DestroyAllChildren()
    {
        // Loop through all child objects
        foreach (Transform child in transform)
        {
            // Destroy each child GameObject
            Destroy(child.gameObject);
        }
    }
}
