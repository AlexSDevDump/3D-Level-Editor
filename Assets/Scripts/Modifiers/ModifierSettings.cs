using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierSettings : MonoBehaviour
{
    public Modifier mod;
    public Waypoint_NoInher wayp;
    public GameObject waypointObject;

    public void AddWaypoint()
    {
        GameObject w = Instantiate(waypointObject, wayp.transform.position, Quaternion.identity);
        wayp.waypoints.Add(w.transform);
    }
}
