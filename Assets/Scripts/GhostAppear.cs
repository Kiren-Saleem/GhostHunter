using UnityEngine;
using System.Collections;

public class GhostAppear : MonoBehaviour
{
    public float visibleTime = 3f;

    public void AppearAt(Vector3 position)
    {
        StopAllCoroutines();
        StartCoroutine(Appear(position));
    }

    IEnumerator Appear(Vector3 position)
    {
        transform.position = position;

        gameObject.SetActive(true);

        yield return new WaitForSeconds(visibleTime);

        gameObject.SetActive(false);
    }
}