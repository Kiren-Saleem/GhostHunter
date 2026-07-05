using System.Collections;
using UnityEngine;

public class BookInteraction : MonoBehaviour
{
    public GameObject fireEffect;

    public EquipmentManager equipment;
    public InventoryManager inventoryManager;
    private bool playerNear = false;
    private bool burned = false;

    void Start()
    {
        fireEffect.SetActive(false);
    }

    void Update()
    {
        if (playerNear &&
            !burned &&
            equipment.candleEquipped &&
            Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(BurnBook());
        }
    }

    IEnumerator BurnBook()
    {
        burned = true;

        fireEffect.SetActive(true);

        Debug.Log("Book is burning...");

        yield return new WaitForSeconds(3f);
        inventoryManager.CollectBook();
        gameObject.SetActive(false);

        Debug.Log("Book destroyed.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press P to burn the book.");
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