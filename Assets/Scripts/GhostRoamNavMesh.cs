
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GhostRoamNavMesh : MonoBehaviour
{
    public Transform[] waypoints;

    private NavMeshAgent agent;
    private bool waiting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        int randomIndex =
            UnityEngine.Random.Range(0, waypoints.Length);

        transform.position =
            waypoints[randomIndex].position;

        ChooseNewDestination();
    }

    void Update()
    {
        if (!waiting &&
            !agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(WaitAndMove());
        }
    }

    IEnumerator WaitAndMove()
    {
        waiting = true;

        yield return new WaitForSeconds(
            Random.Range(2f, 3f)
        );

        ChooseNewDestination();

        waiting = false;
    }

    void ChooseNewDestination()
    {
        int randomIndex =
            Random.Range(0, waypoints.Length);

        agent.SetDestination(
            waypoints[randomIndex].position
        );
    }
}