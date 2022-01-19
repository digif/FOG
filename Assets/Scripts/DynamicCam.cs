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

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3
        {
            x = playerSpeed.Value.x * maxXOffset,
            y = playerSpeed.Value.normalized.y * maxYOffset,
            z = this.transform.position.z
        };
        this.transform.position = Vector3.MoveTowards(this.transform.position, offset, camSpeed * Time.deltaTime);

    }

    void LateUpdate()
    {
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, playerTransform.rotation.z * -1.0f);
    }
}
