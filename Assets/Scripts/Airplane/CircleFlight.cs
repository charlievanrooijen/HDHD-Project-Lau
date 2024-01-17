using UnityEngine;

public class WaypointFlight : MonoBehaviour
{
    public GameObject[] waypoints; // Array of waypoints
    public float speed = 5f; // Speed of the airplane
    private int currentWaypointIndex = 0; // Current waypoint index

    void Update()
    {
        if (waypoints.Length == 0) return;

        GameObject currentWaypoint = waypoints[currentWaypointIndex];
        Vector3 targetDirection = currentWaypoint.transform.position - transform.position;

        // Move towards the waypoint
        transform.position += targetDirection.normalized * speed * Time.deltaTime;

        // Optionally, make the airplane face the direction of movement
        transform.LookAt(currentWaypoint.transform.position);

        // Check if the waypoint has been reached
        if (Vector3.Distance(transform.position, currentWaypoint.transform.position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
