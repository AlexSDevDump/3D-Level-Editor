using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Move_Between : Modifier
{
    [SerializeField]
    private bool moving;
    [SerializeField]
    private Transform[] waypoints;
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
    }

    public void StartMovement()
    {
        StartCoroutine(ModFunction());
    }

    private void NextTarget()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length) { currentWaypointIndex = 0; }
        currentTarget = waypoints[currentWaypointIndex];
        StartCoroutine(ModFunction());
    }

    protected override IEnumerator ModFunction()
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
