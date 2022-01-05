using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCam : MonoBehaviour
{
    // variables
    [SerializeField]
    Vector2Variable playerSpeed = null;

    [SerializeField]
    Vector2Variable playerPosition = null;

    // parameters
    [SerializeField]
    float maxOffset = 2;

    [SerializeField]
    float camSpeed = 2;

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = playerSpeed.Value.normalized * maxOffset + playerPosition.Value;

        transform.position = Vector3.MoveTowards(transform.position, offset, camSpeed * Time.deltaTime);
    }
}
