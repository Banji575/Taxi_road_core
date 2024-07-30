using UnityEngine;

public class Intersection : MonoBehaviour
{
    private Vector3[] waypoints;


    private void Start()
    {
        Waypoint[] waypointComopnents = GetComponentsInChildren<Waypoint>();
        waypoints = new Vector3[waypointComopnents.Length];

        for(int i = 0; i<waypoints.Length; i++)
        {
            waypoints[i] = waypointComopnents[i].transform.position;
        }
    }

    public Vector3 GetClosestWaypoint(Vector3 position)
    {
        Vector3 closesWaypoint = new Vector3(0,0,0);
        float closesDistance = Mathf.Infinity;

        foreach(var waypoint in waypoints)
        {
            float distance = Vector3.Distance(position, waypoint);

            if(distance < closesDistance)
            {
                closesDistance = distance;
                closesWaypoint = waypoint;
            }
        }

        return closesWaypoint;
    }
}
