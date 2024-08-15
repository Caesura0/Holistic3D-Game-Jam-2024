using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemChest : MonoBehaviour, IInteractable
{
    [SerializeField] Item itemInChest;
    [SerializeField] int itemQuantity = 1;

    [SerializeField] float strength = .1f;
    [SerializeField] float shakeTime = .8f;
    [SerializeField] int vibrato = 16;


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
        transform.DOShakePosition(shakeTime, strength, vibrato, 0);
        SoundManager.Instance.PlayChestUnlockSound();
        //transform.DOShakePosition(0.3, .8, 15,90, false);

    }

    public void ShakeChest()
    {
        if(!isChestLocked && !isItemTaken)
        {
            transform.DOShakePosition(shakeTime, strength, vibrato, 0);
        }
    }

    public void Interact(Player player)
    {
        if (!isChestLocked && !isItemTaken)
        {
            animator.Play("ChestOpening");
            isItemTaken = true;
            InventoryManager.Instance.AddItem(itemInChest, itemQuantity);

        }
        if (isChestLocked)
        {
            transform.DOShakePosition(shakeTime, strength, vibrato, 0);
            SoundManager.Instance.PlayChestLockedSound();
        }
    }
}
