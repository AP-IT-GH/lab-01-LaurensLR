using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform[] waypoints;
    public int currentWaypoint = 0;
    public float distanceCheck = 2.0f;
    public float rotSpeed = 2.0f;
    public float speed = 5.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0) return;

        Vector3 direction = waypoints[currentWaypoint].transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime
        * rotSpeed);

        if (direction.magnitude < distanceCheck)
            currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
            currentWaypoint = 0;

        transform.Translate(0, 0, speed * Time.deltaTime);

    }
}
