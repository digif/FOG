using UnityEngine;
using UnityEngine.InputSystem;

enum Autorun
{
    DISABLED,
    LEFT,
    RIGHT
}


[RequireComponent(typeof(Rigidbody2D))]
public class Run : MonoBehaviour
{
    // variables
    [SerializeField]
    Vector2Variable playerSpeed = null;


    // parameters
    [SerializeField]
    FloatVariable runSpeed = null;

    [SerializeField]
    FloatVariable autoRunDelay = null;


    // states
    [SerializeField]
    BoolVariable isAutorunLevel = null;

    [SerializeField]
    BoolVariable isAutorunDirectionLeft = null;

    [SerializeField]
    BoolVariable isDead = null;

    [SerializeField]
    CapsuleCollider2DVariable fitCollider = null;


    // events
    [SerializeField]
    GameEvent onLevelStarted = null;


    // components
    [SerializeField]
    Rigidbody2D rb = null;


    // variables
    Vector2 currentSpeed;

    float currentDelay;

    Autorun autorun;

    [SerializeField] // TODO: set bootstrap back up 
    bool isLevelLoaded = false;


    void Awake()
    {
        onLevelStarted.Add(OnLevelStarted);
        rb.freezeRotation = true;
        currentSpeed = Vector2.zero;
        currentDelay = autoRunDelay.Value;

        if (isAutorunLevel.Value)
        {
            if (isAutorunDirectionLeft.Value)
                autorun = Autorun.LEFT;
            else
                autorun = Autorun.RIGHT;
        }
        else
            autorun = Autorun.DISABLED;
    }

    private void OnDisable() {
        onLevelStarted.Remove(OnLevelStarted);
    }

    void OnLevelStarted ()
    {
        isLevelLoaded = true;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if(autorun == Autorun.DISABLED)
        {
            float value = context.ReadValue<float>();
            if (value > 0.1)
                currentSpeed = Vector2.right;
            else if (value < -0.1)
                currentSpeed = Vector2.left;
            else
                currentSpeed = Vector2.zero;
        }
    }

    private void FixedUpdate() {

        if (isLevelLoaded)
        {
            if (currentDelay > 0)
                currentDelay -= Time.deltaTime;
            else
                switch (autorun)
                {
                    case Autorun.LEFT:
                    currentSpeed = Vector2.left;
                    break;
                    case Autorun.RIGHT:
                    currentSpeed = Vector2.right;
                    break;
                }

            if (!isDead.Value && !fitCollider.Value.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rb.position += currentSpeed * runSpeed.Value * Time.fixedDeltaTime;
                playerSpeed.Value = rb.velocity + currentSpeed * runSpeed.Value;
            }
        }
    }
}