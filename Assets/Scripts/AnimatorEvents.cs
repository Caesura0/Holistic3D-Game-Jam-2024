using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    Animator animator;

    Player player;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
    }

    public void OnAnimationEnd()
    {
        player.OnAnimationEnd();
    }

    public void CanMoveNow()
    {
        player.CanMoveNow();
    }
}
