using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    public void Interact(Player player)
    {
        Debug.Log("Trash picked up by " + player.name);
        //playsound

        //disapear
        player.PickUpGarbage();
        Destroy(gameObject);
        //particleEffect?
    }


}
