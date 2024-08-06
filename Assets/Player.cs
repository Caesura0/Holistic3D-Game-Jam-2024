using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{


    public static event Action<int> OnTrashPickedUp;

    [SerializeField] float moveSpeed;
    [SerializeField] LayerMask interactableLayer;

    int trashPickedUp;


    public float lastMoveX;
    public float lastMoveY;

    //bool canMove = true;
    bool isMoving;

    Animator animator;

    public Vector2 movement;

    



    Rigidbody2D rb;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerInput();
        CheckForInteract();
    }

    private void PlayerInput()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        
        if(movement != Vector2.zero)
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
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 facingDirection = new Vector2(lastMoveX, lastMoveY);
            float distance = 1.7f;
            Vector2 lineEndPosition = (Vector2)transform.position + facingDirection * distance;
            Debug.Log(facingDirection);
            Debug.DrawLine(transform.position, lineEndPosition, Color.red, 10f);
            var hit = Physics2D.Raycast(transform.position, facingDirection, distance, interactableLayer );
            if(hit.transform != null && hit.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact(this);
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

}
