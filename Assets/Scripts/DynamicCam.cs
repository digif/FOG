using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCam : MonoBehaviour
{
    // variables
    [SerializeField]
    Vector2Variable playerSpeed = null;

    [SerializeField]
    Transform playerPosition = null;

    // parameters
    [SerializeField]
    float maxOffset = 4;

    [SerializeField]
    float camSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = (Vector3) playerSpeed.Value.normalized * maxOffset + playerPosition.position;
        offset.z = -10;

        transform.position = Vector3.MoveTowards(transform.position, offset, camSpeed * Time.deltaTime);
    }
}
