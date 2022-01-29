using UnityEngine;

public class DynamicCam : MonoBehaviour
{
    // variables
    [SerializeField]
    Vector2Variable playerSpeed = null;

    [SerializeField]
    Transform playerTransform = null;



    // parameters
    [SerializeField]
    float maxXOffset = 5;

    [SerializeField]
    float maxYOffset = 5;

    [SerializeField]
    float camSpeed = 20;

    // test
    [SerializeField]
    Vector3 offset;

    [SerializeField]
    Vector3 transPosition;

    [SerializeField]
    Vector3 moveToPosition;


    // Update is called once per frame
    void Update()
    {
        transPosition = this.transform.localPosition;

        float xSpeed = playerSpeed.Value.x;
        if (xSpeed > 1)
            xSpeed = 1;
        if (xSpeed < -1)
            xSpeed = -1;

        offset = new Vector3
        {
            x = xSpeed * maxXOffset,
            y = transPosition.y,
            z = transPosition.z
        };

        moveToPosition = Vector3.MoveTowards(transPosition, offset, camSpeed * Time.deltaTime);
        this.transform.localPosition = moveToPosition;

    }

    void LateUpdate()
    {
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, playerTransform.rotation.z * -1.0f);
    }
}
