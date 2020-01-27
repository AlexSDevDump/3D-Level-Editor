using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Move_Between : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        StartMovement();
    }

    void Update()
    {

    }

    public void StartMovement()
    {
        currentTarget = waypoints[0];
        StartCoroutine(Movement(delay));
    }

    IEnumerator Movement(float waitTime)
    {
        while (Vector3.Distance(transform.position, currentTarget.position) > 0.001f)
        {
            Debug.Log("Moving");
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);
        NextTarget();
    }

    private void NextTarget()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length) { currentWaypointIndex = 0; }
        currentTarget = waypoints[currentWaypointIndex];
        StartCoroutine(Movement(delay));
    }
}
