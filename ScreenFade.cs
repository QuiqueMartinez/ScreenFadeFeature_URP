using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScreenFade : MonoBehaviour
{
    // Settings
    [Range(0, 1)] public float duration = 0.5f;
    private Material fadeMaterial = null;

    // Runtime
    private void Start()
    {
        SetupFadeFeature();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Fade in
            StartCoroutine(cFadeIn(duration));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Fade out
            StartCoroutine(cFadeOut(duration));
        }
    }

    private void SetupFadeFeature()
    {
        ScreenFadeFeature screenFade = null;

        var allRenderers = Resources.FindObjectsOfTypeAll<UniversalRendererData>();
        foreach (var renderer in allRenderers)
        {
            var feature = renderer.rendererFeatures.Find(f => f is ScreenFadeFeature) as ScreenFadeFeature;
            if (feature != null)
            {
                screenFade = feature;
                break;
            }
        }

        if (screenFade == null)
        {
            Debug.LogWarning("ScreenFadeFeature not found UniversalRendererData.");
            return;
        }

        fadeMaterial = Instantiate(screenFade.settings.material);
        screenFade.settings.runTimeMaterial = fadeMaterial;

        // Starts faded out
        fadeMaterial.SetFloat("_Alpha", 1);
    }

    IEnumerator cFadeIn(float duration = 0.5f)
    {
        // Fade to transparent
        fadeMaterial.SetFloat("_Alpha", 1);

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float alphaValue = Mathf.Lerp(1, 0, t / duration);
            fadeMaterial.SetFloat("_Alpha", alphaValue);
            yield return null;
        }
        fadeMaterial.SetFloat("_Alpha", 0);
    }

    IEnumerator cFadeOut(float duration = 0.5f)
    {
        // Fade to black
        fadeMaterial.SetFloat("_Alpha", 0);

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float alphaValue = Mathf.Lerp(0, 1, t / duration);
            fadeMaterial.SetFloat("_Alpha", alphaValue);
            yield return null;
        }
        fadeMaterial.SetFloat("_Alpha", 1);
    }
}