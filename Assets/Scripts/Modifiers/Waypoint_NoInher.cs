using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_NoInher : MonoBehaviour
{
    [SerializeField]
    private bool moving;
    public List<Transform> waypoints;
    [SerializeField]
    private Transform currentTarget;
    [SerializeField]
    private int currentWaypointIndex;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float delay;

    void Start()
    {
        StartMovement();
        waypoints = new List<Transform>();
    }

    public void StartMovement()
    {
        StartCoroutine(ModFunction());
    }

    private void NextTarget()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Count) { currentWaypointIndex = 0; }
        currentTarget = waypoints[currentWaypointIndex];
        StartCoroutine(ModFunction());
    }

     private IEnumerator ModFunction()
    {
        if (moving)
        {
            if (currentTarget == null) { currentTarget = waypoints[0]; }
            while (Vector3.Distance(transform.position, currentTarget.position) > 0.001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(delay);
            NextTarget();
        }

        else
        {
            yield return null;
            StartMovement();
        }
    }
}
