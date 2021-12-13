using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    // parameters
    [SerializeField]
    FloatVariable jumpPower = null;
    
    [SerializeField]
    FloatVariable topFallSpeed = null;


    // events
    [SerializeField]
    GameEvent OnJump = null;


    // states
    [SerializeField]
    BoolVariable isGrounded = null;


    // components
    [SerializeField]
    Rigidbody2D rb = null;


    public void OnJumpInput(InputAction.CallbackContext context)
    {
        // jump if on the ground and button pressed
        if (isGrounded.Value && context.started)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower.Value);
            OnJump.Raise();
        }
    }

    void FixedUpdate() {
        // limit top fall speed
        float verticalSpeed = 
            (rb.velocity.y > 0 ? 1: -1) * Mathf.Clamp(Mathf.Abs(rb.velocity.y), 0, topFallSpeed.Value);
        rb.velocity = new Vector2( rb.velocity.x, verticalSpeed);
    }
}
