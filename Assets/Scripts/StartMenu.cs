using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private string nextSceneName = "GameScene"; // Set your next scene name here

    private AudioSource audioSource;

    private void Start()
    {

        audioSource = gameObject.AddComponent<AudioSource>();
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        PlayButtonSound();
        FadeOutAndLoadScene(nextSceneName);
    }

    private void QuitGame()
    {
        PlayButtonSound();
        FadeOutAndQuit();
    }

    private void PlayButtonSound()
    {
        if (buttonSound != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }

    private void FadeOutAndLoadScene(string sceneName)
    {
        canvasGroup.DOFade(1, fadeDuration).OnComplete(() => SceneManager.LoadScene(sceneName));
    }

    private void FadeOutAndQuit()
    {
        canvasGroup.DOFade(1, fadeDuration).OnComplete(() => Application.Quit());
    }
}