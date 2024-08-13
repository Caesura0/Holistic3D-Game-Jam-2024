using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour, IInteractable
{
    [SerializeField] Item itemInChest;
    [SerializeField] int itemQuantity = 1;


    Animator animator;

    public bool isChestLocked = true;
    public bool isItemTaken = false;
     

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void UnlockChest()
    {
        isChestLocked = false;
        //playsound
    }

    public void Interact(Player player)
    {
        if (!isChestLocked && !isItemTaken)
        {
            animator.Play("ChestOpening");
            isItemTaken = true;
            InventoryManager.Instance.AddItem(itemInChest, 1);

        }
    }
}
