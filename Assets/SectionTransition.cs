using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SectionTransition : MonoBehaviour
{

    Collider2D enterTrigger;


    [SerializeField] Transform newArea;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    private bool isTransitioning;

    // Start is called before the first frame update


    void Start()
    {
        enterTrigger = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {

            StartCoroutine(Transition(player));
        }
    }


    private IEnumerator Transition( Player player)
    {
        isTransitioning = true;
        player.CanMove(false);
        SceneFadeTransition.Instance.Fade(1);
        // Fade out
        yield return StartCoroutine(SceneFadeTransition.Instance.Fade(1));


        player.transform.position = newArea.position;
        virtualCamera.ForceCameraPosition(player.transform.position, Quaternion.identity);
        // Fade in
        yield return StartCoroutine(SceneFadeTransition.Instance.Fade(0));
        player.CanMove(true);
        isTransitioning = false;
    }

}
