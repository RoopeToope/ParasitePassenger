using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolMovement : MonoBehaviour {
    [SerializeField] Transform[] waypoints;
    [SerializeField] float nearEnough = 1;
    int nextWaypoint = 0;
    NavMeshAgent agent;

    void StartTowardNextWayPoints() {
        agent.destination = waypoints[nextWaypoint].position;
    }
    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        StartTowardNextWayPoints();
    }
    void Update() {
        if (Vector3.Distance(transform.position, waypoints[nextWaypoint].position) < nearEnough) {
            nextWaypoint++;

            if (nextWaypoint >= waypoints.Length) {
                nextWaypoint = 0;
            }
            StartTowardNextWayPoints();

        }



    }
}

