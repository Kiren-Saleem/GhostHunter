

using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public GameObject Door_closed1;
    public GameObject Door_closed2;
    public GameObject Door_opened1;
    public GameObject Door_opened2;

    private bool playerNear = false;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.P) && inventoryManager.hasBook)
        {
            inventoryManager.CollectKey();

            Destroy(gameObject);
            Door_closed1.SetActive(false);
            Door_closed2.SetActive(false);
            Door_opened1.SetActive(true);
            Door_opened2.SetActive(true);
            Debug.Log("Rusty Key Collected!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press P to pick up the Rusty Key.");
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