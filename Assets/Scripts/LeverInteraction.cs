

using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public Transform bed;
    public float liftHeight = 2f;
    public float liftSpeed = 2f;
    public LighterEffect lighter;
    public Light lighterLight;
    private bool playerNear = false;
    private bool activated = false;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = bed.position + Vector3.up * liftHeight;
    }

    void Update()
    {
        if (playerNear && !activated && Input.GetKeyDown(KeyCode.P))
        {
            activated = true;
            lighter.StartEffect();
        }

        if (activated)
        {
            bed.position = Vector3.MoveTowards(
                bed.position,
                targetPosition,
                liftSpeed * Time.deltaTime
            );

            if (lighterLight != null)
            {
                lighterLight.intensity = Mathf.MoveTowards(
                    lighterLight.intensity,
                    2f,
                    Time.deltaTime
                );
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Press P to pull the lever");
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