using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] AudioSoundsSO audioSoundsSO;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip clip, float volume = 1)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, volume);
    }

    //public void PlaySound(AudioClip clip, Vector3 position)
    //{
    //    AudioSource.PlayClipAtPoint(clip, position);
    //}

    void PlayRandomSoundFromArray(AudioClip[] audioClipArray, float volume = 1)
    {
        if (audioClipArray.Length == 0) return;
        var soundArray = audioClipArray;
        int choice = Random.Range(0, soundArray.Length);
        AudioClip sound = soundArray[choice];
        PlaySound(sound, volume);
    }

    public void PlayTypingSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.dialogueTyping, 0.9f);
    }

    public void PlayOpenDialogueSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.openDialogue);
    }

    public void PlayQuestStartedSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.questStarted);
    }

    public void PlayQuestFinishedSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.questFinished);
    }

    public void PlayAxeSwingSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.axeSwing);
    }

    public void PlayAxeChoppingTreeSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.axeChoppingTree);
    }

    public void PlayPickaxeSwingSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.pickaxeSwing);
    }

    public void PlayPickaxeHitSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.pickaxeHit);
    }

    public void PlayWateringSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.watering);
    }

    public void PlayFillWateringCanSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.fillWateringCan);
    }

    public void PlaySwitchItemsSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.switchItems);
    }

    public void PlayClickStartSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.clickStart);
    }

    public void PlayMilkCowSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.milkCow);
    }

    public void PlayCowMooSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.cowMoo);
    }

    public void PlayFootstepsSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.footsteps);
    }
    public void PlayItemPickupSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.itemPickup, 0.9f);
    }

    public void PlayChestUnlockSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.chestUnlock);
    }
    public void PlayChestLockedSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.chestLockedRattle);
    }

    public void PlayQuestPopupSound()
    {
        PlayRandomSoundFromArray(audioSoundsSO.questPopup);
    }

}
