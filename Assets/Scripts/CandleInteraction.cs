
using UnityEngine;

public class CandleInteraction : MonoBehaviour
{
    public GameObject flame;
    public GameObject smoke;
    public GameObject pointLight;
    public AudioSource cracklingSound;

    public InventoryManager inventoryManager;
    public EquipmentManager equipment;

    private bool playerNear = false;
    private bool isLit = false;

    void Start()
    {
        flame.SetActive(false);
        smoke.SetActive(false);
        pointLight.SetActive(false);

        if (cracklingSound != null)
            cracklingSound.Stop();
    }

    void Update()
    {
        if (playerNear)
        {
            Debug.Log("Player Near");
            Debug.Log("Lighter Equipped: " + equipment.lighterEquipped);
        }

        if (playerNear &&
            !isLit &&
            equipment.lighterEquipped &&
            Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Lighting Candle");
            LightCandle();
        }
    }

    void LightCandle()
    {
        isLit = true;
        flame.SetActive(true);
        smoke.SetActive(true);
        pointLight.SetActive(true);

        if (cracklingSound != null)
            cracklingSound.Play();

        inventoryManager.CandleLit();

        Debug.Log("Candle Lit!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press E to light the candle.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
}