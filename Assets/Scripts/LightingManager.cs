using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] Light DirectionalLight;
    [SerializeField] LightingPreset Preset;

    [SerializeField, Range(0, 10)] float TimeOfDay;

    private float cycleDuration = 30f;
    private float timeAccumulator = 0f;
    private void Update()
    {
        if (Preset == null) return;

        if (Application.isPlaying)
        {
            timeAccumulator += Time.deltaTime;

            if (timeAccumulator >= cycleDuration)
            {
                timeAccumulator = 0f; // Döngüyü resetle
                TimeOfDay = TimeOfDay >= 5 ? 0f : 5f; // Gündüz/gece arasýnda geçiþ yap
            }

            float transitionPercent = timeAccumulator / cycleDuration; // Geçiþ yüzdesi
            UpdateLighting((TimeOfDay + transitionPercent * 5f) / 10f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 10f);
        }
    }
    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 170f), 170f, 0));
        }

    }
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
