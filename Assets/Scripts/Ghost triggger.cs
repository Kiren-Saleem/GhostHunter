using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    public GhostAppear ghost;

    public Vector3 offset = new Vector3(0, 0, 2);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ghost.AppearAt(transform.position + offset);

            gameObject.SetActive(false);
        }
    }
}