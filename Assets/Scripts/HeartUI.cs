using TMPro;
using UnityEngine;

public class HeartUI : MonoBehaviour
{
    public TMP_Text heartText;

    void Update()
    {
        switch (HealthManager.Instance.lives)
        {
            case 3:
                heartText.text = "♥♥♥";
                break;

            case 2:
                heartText.text = "♥♥";
                break;

            case 1:
                heartText.text = "♥";
                break;

            case 0:
                heartText.text = "";
                break;
        }
    }
}