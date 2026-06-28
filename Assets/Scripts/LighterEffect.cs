using UnityEngine;

public class LighterEffect : MonoBehaviour
{
    public float rotationSpeed = 80f;

    private bool rotate = false;

    void Update()
    {
        if (rotate)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    public void StartEffect()
    {
        rotate = true;
    }
}