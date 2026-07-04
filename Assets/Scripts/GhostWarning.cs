using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GhostWarning : MonoBehaviour
{
    public Volume globalVolume;

    private ColorAdjustments colorAdjustments;

    void Start()
    {
        globalVolume.profile.TryGet(out colorAdjustments);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colorAdjustments.colorFilter.value = new Color(1f, 0.4f, 0.4f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colorAdjustments.colorFilter.value = Color.white;
        }
    }
}