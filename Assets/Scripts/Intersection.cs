using UnityEngine;

public class Intersection : MonoBehaviour
{
    private Transform[] waypoints;


    private void Start()
    {
        Waypoint[] waypointComopnents = GetComponentsInChildren<Waypoint>();
        waypoints = new Transform[waypointComopnents.Length];

        for(int i = 0; i<waypoints.Length; i++)
        {
            waypoints[i] = waypointComopnents[i].transform;
        }
    }

    public Transform GetClosestWaypoint(Vector3 position)
    {
        Transform closesWaypoint = null;
        float closesDistance = Mathf.Infinity;

        foreach(var waypoint in waypoints)
        {
            float distance = Vector3.Distance(position, waypoint.position);

            if(distance < closesDistance)
            {
                closesDistance = distance;
                closesWaypoint = waypoint;
            }
        }

        return closesWaypoint;
    }
}
