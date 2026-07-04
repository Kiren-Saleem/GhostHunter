
using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    private bool hasAttacked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasAttacked)
            return;

        if (other.CompareTag("Player"))
        {
            hasAttacked = true;

            HealthManager.Instance.LoseLife();

            Debug.Log("Ghost Attacked!");
        }
    }
}