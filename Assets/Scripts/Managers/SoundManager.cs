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
        if (themeGameObject == null) // Temanýn zaten çalmadýðýndan emin olun
        {
            themeGameObject = new GameObject("GameTheme");
            themeAudioSource = themeGameObject.AddComponent<AudioSource>();
            themeAudioSource.loop = true; // Döngüye al
            themeAudioSource.clip = GetAudioClip(soundType);
            themeAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Game theme is already playing!");
        }
    }
    public static void StopGameTheme()
    {
        if (themeGameObject != null && themeAudioSource != null)
        {
            themeAudioSource.Stop();
            GameObject.Destroy(themeGameObject);
            themeGameObject = null;
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
