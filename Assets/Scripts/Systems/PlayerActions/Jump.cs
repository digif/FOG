using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    #region Fields

    [SerializeField] private FloatVariable jumpPower = null;
    [SerializeField] private FloatVariable topFallSpeed = null;

    [SerializeField] private GameEvent OnJump = null;
    
    [SerializeField] private BoolVariable isGrounded = null;
    [SerializeField] private BoolVariable isAboveGround = null;
    
    private Rigidbody2D rigidbody = null;
    private int groundCount;
    private Coroutine resetGroundedCoroutine;

    #endregion
    
    #region Unity Event Methods

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        isAboveGround.OnValueChange += AboveGround;
    }

    private void OnDestroy()
    {
        isAboveGround.OnValueChange -= AboveGround;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != 3) return; // Ground layer

        if (resetGroundedCoroutine != null)
        {
            StopCoroutine(resetGroundedCoroutine);
        }
        
        resetGroundedCoroutine = StartCoroutine(SetGrounded(isAboveGround.Value, 0.1f));

        groundCount++;
        isGrounded.Value = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer != 3) return; // Ground layer

        groundCount--;
        if (groundCount > 0) return;

        if (resetGroundedCoroutine != null)
        {
            StopCoroutine(resetGroundedCoroutine);
        }
        
        resetGroundedCoroutine = StartCoroutine(SetGrounded(isAboveGround.Value, 0.1f));
    }

    private void FixedUpdate()
    {
        // limit top fall speed
        var velocity = rigidbody.velocity;
        var verticalSpeed = 
            (velocity.y > 0 ? 1: -1) * Mathf.Clamp(Mathf.Abs(velocity.y), 0, topFallSpeed.Value);
        rigidbody.velocity = new Vector2( rigidbody.velocity.x, verticalSpeed);
    }

    #endregion

    #region Inputs

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        // jump if on the ground and button pressed
        if (!isGrounded.Value || !context.started) return;
        if (!isAboveGround.Value) return;

        rigidbody.velocity = new Vector2(0, jumpPower.Value);
        if (resetGroundedCoroutine != null)
        {
            StopCoroutine(resetGroundedCoroutine);
        }
        
        isGrounded.Value = false;
        OnJump.Raise();
    }

    #endregion

    #region Private Methods

    private void AboveGround()
    {
        if (resetGroundedCoroutine != null)
        {
            StopCoroutine(resetGroundedCoroutine);
        }
        
        resetGroundedCoroutine = StartCoroutine(SetGrounded(isAboveGround.Value && groundCount > 0, 0.1f));
    }
    
    private IEnumerator SetGrounded(bool value, float time)
    {
        yield return new WaitForSeconds(time);

        print(isAboveGround.Value);
        print(value);
        isGrounded.Value = value;
    }

    #endregion
}
