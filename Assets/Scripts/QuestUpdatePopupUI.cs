using UnityEngine;
using TMPro;
using DG.Tweening;

public class QuestUpdatePopupUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        questText = GetComponentInChildren<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
        Quest.OnAnyQuestChanged += Quest_OnAnyQuestChanged;
        gameObject.SetActive(false);
    }

    private void Quest_OnAnyQuestChanged(object sender, Quest.QuestChangedEventArgs e)
    {
        // Set initial alpha to 0 and activate the game object
        canvasGroup.alpha = 0;
        gameObject.SetActive(true);

        // Update quest text
        questText.text = e.QuestName + " : " + e.QuestStatus;

        // Sequence to handle the fade in, wait, and fade out
        Sequence sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.DOFade(1, 0.7f))  // Fade in over 0.7 seconds
                .AppendInterval(3f)                   // Wait for 3 seconds
                .Append(canvasGroup.DOFade(0, 0.7f))  // Fade out over 0.7 seconds
                .OnComplete(() => gameObject.SetActive(false));  // Deactivate game object after fading out
        SoundManager.Instance.PlayQuestPopupSound();
        sequence.Play();
    }
}
