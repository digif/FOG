using UnityEngine;
using UnityEngine.InputSystem;

public class DynamicCam : MonoBehaviour
{
    #region Fields

    [Header("variables")]

    [SerializeField]
    Transform playerTransform = null;


    [Header("parameters")]
    
    [SerializeField]
    float maxXOffset = 5;

    [SerializeField]
    float maxYOffset = 5;

    [SerializeField]
    float camSpeed = 20;


    [Header("debug - y offset")]

    [SerializeField]
    Vector3 globalPosition;

    [Header("debug - x offset")]

    [SerializeField]
    float inputValueX;

    [SerializeField]
    Vector3 localPosition;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    Vector3 moveToPosition;

    #endregion


    #region Unity Event Methods

    private void Start()
    {
        globalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // y offest
        globalPosition.x = this.transform.position.x;

        if (globalPosition.y - playerTransform.position.y > maxYOffset)
            globalPosition.y = playerTransform.position.y + maxYOffset;

        if (globalPosition.y - playerTransform.position.y < -maxYOffset)
            globalPosition.y = playerTransform.position.y - maxYOffset;

        this.transform.position = globalPosition;

        // x offset
        localPosition = this.transform.localPosition;

        offset = localPosition;
        offset.x = inputValueX * maxXOffset;

        moveToPosition = Vector3.MoveTowards(localPosition, offset, camSpeed * Time.deltaTime);
        this.transform.localPosition = moveToPosition;

    }

    void LateUpdate()
    {
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, playerTransform.rotation.z * -1.0f);
    }
    
    #endregion


    #region Inputs

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        inputValueX = context.ReadValue<Vector2>().x;
    }

    #endregion
}
