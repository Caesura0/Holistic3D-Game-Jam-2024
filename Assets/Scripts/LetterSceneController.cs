using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetterSceneController : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 1f;
    //[SerializeField] private string nextScene;  // Name of the scene to load

    private bool isFading = false;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }



    public void StartFadeOut()
    {
        isFading = true;
        StartCoroutine(FadeOut("GameScene"));
    }

    private IEnumerator FadeIn()
    {
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = 1f - (timeElapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }



    private IEnumerator FadeOut(string nextScene)
    {
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = timeElapsed / fadeDuration;
            yield return null;
        }

        canvasGroup.alpha = 1f;

        // Load the next scene after the fade-out is complete
        SceneManager.LoadScene(nextScene);
    }
}
