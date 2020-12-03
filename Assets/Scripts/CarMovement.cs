using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform[] waypoints;
    private int waypointIndex = 0;

    private float distanceToWaypoint;

    private Rigidbody rb;

    private float moveSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.LookAt(waypoints[waypointIndex].position);
    }

    private void Update()
    {
        distanceToWaypoint = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        if (distanceToWaypoint < 0.1f)
        {
            UpdateIndex();
        }

        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void UpdateIndex()
    {
        waypointIndex++;

        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }

        transform.LookAt(waypoints[waypointIndex].position);
    }

}
