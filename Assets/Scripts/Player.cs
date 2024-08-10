using System;
using System.Collections;
using UnityEngine;



public class Player : MonoBehaviour
{


    public static event Action<int> OnTrashPickedUp;

    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask interactableLayer;



    //for visualizing the circlecast
    [SerializeField] float duration = 1f;
    [SerializeField] int segments = 36; // Number of segments to form the circle


    int trashPickedUp;


    public float lastMoveX;
    public float lastMoveY;

    //bool canMove = true;
    bool isMoving;

    Animator animator;

    public Vector2 movement;


    bool canMove = true;


    Rigidbody2D rb;
    float radius = .3f;


    private static readonly int IdleState = Animator.StringToHash("Idle");

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!SimpleDialogueManager.Instance.InDialogue && canMove)
        {
            PlayerInput();
            CheckForInteract();
            SelectAction();
            CheckForItemUse();
        }
        else
        {
            movement = Vector2.zero;
            rb.velocity = Vector2.zero;
            isMoving = false;
            animator.SetBool("IsMoving", isMoving);
            animator.SetFloat("MovementX", Mathf.Abs(0));
            animator.SetFloat("MovementY", Mathf.Abs(0));
        }

    }

    private void CheckForItemUse()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Item item = (Item)InventoryManager.Instance.GetSelectedItem();

            UseItem(item.itemType);
        }
    }

    void CheckForItemInteractable()
    {
        Debug.Log("check for item Interactable");
        Vector2 facingDirection = new Vector2(lastMoveX, lastMoveY);
        float distance = .6f;
        RaycastHit2D[] hits = Physics2D.CircleCastAll((Vector2)transform.position + facingDirection *.5f * 1.8f, radius, facingDirection, distance, interactableLayer);
        // Sort the hits by distance from the center of the circle
        System.Array.Sort(hits, (hit1, hit2) => hit1.distance.CompareTo(hit2.distance));
 
        foreach (var hit in hits)
        {
            if (hit.transform != null && hit.transform.TryGetComponent<IItemInteractable>(out IItemInteractable itemInteractable))
            {
                if (itemInteractable.ItemInteract())
                {
                    break;
                }
            }
        }

    }
    private void UseItem(ItemType itemType)
    {
        canMove = false;
        switch (itemType)
        {
            case ItemType.Bottle:
                BottleLogic();
                break;
            case ItemType.Hoe:
                HoeLogic();
                break;
            case ItemType.PickAxe:
                PickAxeLogic();
                break;
            case ItemType.Axe:
                AxeLogic();
                break;
            case ItemType.WateringCan:
                WateringCanLogic();
                break;
            case ItemType.Seed:
                SeedLogic();
                break;
            default:
                Debug.Log(canMove);
                canMove = true;
                break;
        }
    }

    private void SeedLogic()
    {
        OnAnimationEnd();

        //seed planting animation
        //instantiate 
    }

    private void WateringCanLogic()
    {
        AnimationPlay("Watering");

        //watering sound
        //instantiate plant
        //change tile color?
    }

    private void AxeLogic()
    {
        AnimationPlay("Axe");

        //tree life bar?
        //tree falling animation
    }

    private void PickAxeLogic()
    {
        AnimationPlay("Hoe");


    }

    private void HoeLogic()
    {
        AnimationPlay("Hoe");

    }

    private void BottleLogic()
    {
        CheckForItemInteractable();
        //if next to cow
        //and bottle is empty
        //play bottle sound
        //remove one bottle
        //add new item full bottle
    }

    private void SelectAction()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            InventoryManager.Instance.SelectUISlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            InventoryManager.Instance.SelectUISlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            InventoryManager.Instance.SelectUISlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            InventoryManager.Instance.SelectUISlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            InventoryManager.Instance.SelectUISlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            InventoryManager.Instance.SelectUISlot(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            InventoryManager.Instance.SelectUISlot(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            InventoryManager.Instance.SelectUISlot(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            InventoryManager.Instance.SelectUISlot(8);
        }

    }

    private void PlayerInput()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (movement != Vector2.zero)
        {
            isMoving = true;
            lastMoveX = movement.x;
            if (lastMoveX != 0)
            {
                lastMoveY = 0f;
            }
            else
            {
                lastMoveY = movement.y;
            }

        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("IsMoving", isMoving);
        animator.SetFloat("MovementX", movement.x);
        animator.SetFloat("MovementY", movement.y);

        if (isMoving)
        {
            animator.SetFloat("LastMovementX", lastMoveX);
            animator.SetFloat("LastMovementY", lastMoveY);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        rb.velocity = movement * moveSpeed * Time.deltaTime;

    }


    void CheckForInteract()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            Vector2 facingDirection = new Vector2(lastMoveX, lastMoveY);
            float distance = .6f;
            RaycastHit2D[] hits = Physics2D.CircleCastAll((Vector2)transform.position + facingDirection * .4f, radius, facingDirection, distance, interactableLayer);
            // Sort the hits by distance from the center of the circle
            System.Array.Sort(hits, (hit1, hit2) => hit1.distance.CompareTo(hit2.distance));
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform != null && hit.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    interactable.Interact(this);
                }
            }
  

        }
    }

    public void PickUpGarbage()
    {
        trashPickedUp++;
        OnTrashPickedUp?.Invoke(trashPickedUp);
    }
    public int GetGarbagePickedUp()
    {
        return trashPickedUp;
    }


    public void AddItem(Item item, int quantity)
    {
        InventoryManager.Instance.AddItem(item, quantity);

    }

    public void RemoveItem(Item item, int quantity)
    {
        InventoryManager.Instance.RemoveItem(item, quantity);
    }


    private void AnimationPlay(string animationName)
    {
        // Play the animation
        animator.Play(animationName);


    }

    public void OnAnimationEnd()
    {

        CheckForItemInteractable();
        canMove = true;
    }


}

