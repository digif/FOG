using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    float WPradius = 1;

    bool isLevelLoaded = false;

    // events
    [SerializeField]
    GameEvent onLevelStarted = null;

    private void Awake() {
        onLevelStarted.Add(OnLevelStarted);
    }

    private void OnDisable() {
        onLevelStarted.Remove(OnLevelStarted);
    }

    void OnLevelStarted ()
    {
        isLevelLoaded = true;
    }
    
    void FixedUpdate()
    {
        if (isLevelLoaded)
        {
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                current += 1;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
    }
}