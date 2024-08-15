using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverController : MonoBehaviour
{
    [SerializeField] GameObject giantRock;

    public void FlowingRiver()
    {
        gameObject.SetActive(true);
        giantRock.SetActive(false);
    }


}
