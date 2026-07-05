using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GhostWarning : MonoBehaviour
{
    public Volume globalVolume;

    private ColorAdjustments colorAdjustments;

    // Default scene color
    private Color defaultColor = new Color(81f/225f, 106f / 225f, 170f / 225f);

    void Start()
    {
        globalVolume.profile.TryGet(out colorAdjustments);

        // Set the scene to dark blue when the game starts
        colorAdjustments.colorFilter.value = defaultColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Red warning
            colorAdjustments.colorFilter.value = new Color(1f, 0.4f, 0.4f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Return to dark blue
            colorAdjustments.colorFilter.value = defaultColor;
        }
    }
}