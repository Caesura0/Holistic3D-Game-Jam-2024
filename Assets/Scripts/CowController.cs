using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour, IItemInteractable
{
    [SerializeField] float idleSwitchMinTime = 10f; // Minimum time between switches
    [SerializeField] float idleSwitchMaxTime = 17f; // Maximum time between switches

    [SerializeField] Item itemToBeUsed;
    [SerializeField] Item itemToBeAdded;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetRandomIdleType();
        StartCoroutine(SwitchIdleAnimation());
    }

    private IEnumerator SwitchIdleAnimation()
    {
        while (true)
        {
            // Wait for a random amount of time
            float waitTime = Random.Range(idleSwitchMinTime, idleSwitchMaxTime);
            yield return new WaitForSeconds(waitTime);

            // Set a random idle animation
            SetRandomIdleType();
        }
    }


    private void SetRandomIdleType()
    {
        float idleType = Random.Range(0, 3); // Assuming 3 idle animations
        animator.SetFloat("IdleType", idleType);
    }



    public bool ItemInteract()
    {
        if (InventoryManager.Instance.GetSelectedItem() == itemToBeUsed)
        {
            if (InventoryManager.Instance.ContainsItem(ItemType.Bottle))
            {
                animator.Play("BrownCowHearts");
                Debug.Log("containsBottle");
                InventoryManager.Instance.RemoveItem(itemToBeUsed, 1);
                InventoryManager.Instance.AddItem(itemToBeAdded, 1);
                
            }
            else
            {
                Debug.Log("No Bottle");
            }
            return true;
        }
        return false;
    }
}
