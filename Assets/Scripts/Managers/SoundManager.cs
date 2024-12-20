using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    private static AudioSource themeAudioSource;
    private static GameObject themeGameObject;
    public static void PlaySound(GameAssets.SoundType soundType)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(soundType));
        GameObject.Destroy(soundGameObject, 3f);

    }
    public static void PlayGameTheme(GameAssets.SoundType soundType)
    {
        if (themeAudioSource == null)
        {
            Debug.LogError("Theme AudioSource not initialized. Call InitializeTheme() first.");
            return;
        }

        AudioClip clip = GetAudioClip(soundType);
        if (clip != null)
        {
            themeAudioSource.clip = clip;
            themeAudioSource.loop = true;
            themeAudioSource.Play();
        }
    }
    private static AudioClip GetAudioClip(GameAssets.SoundType soundType)
    {
        foreach (Sound audio in GameAssets.Instance.sounds)
        {
            if (audio.soundType == soundType && audio != null)
            {
                return audio.audio;
            }
        }
        Debug.LogError("Sound" + soundType + "not found!");
        return null;
    }
}
