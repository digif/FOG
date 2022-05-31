using System;
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
    [SerializeField] private BoolVariable isAgainstWall = null;
    
    private Rigidbody2D _rigidbody = null;
    private Transform myTransform;
    private int groundCount;
    private Coroutine resetGroundedCoroutine;

    #endregion
    
    #region Unity Event Methods

    private void Awake()
    {
        myTransform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer != 3) return; // Ground layer

        if (resetGroundedCoroutine != null)
        {
            StopCoroutine(resetGroundedCoroutine);
        }
        
        resetGroundedCoroutine = StartCoroutine(SetGrounded(true, 0.1f));

        groundCount++;
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
        
        resetGroundedCoroutine = StartCoroutine(SetGrounded(false, 0.1f));
    }

    private void FixedUpdate()
    {
        // limit top fall speed
        var velocity = _rigidbody.velocity;
        var verticalSpeed = 
            (velocity.y > 0 ? 1: -1) * Mathf.Clamp(Mathf.Abs(velocity.y), 0, topFallSpeed.Value * (isAgainstWall.Value ? 0.01f : 1f));
        _rigidbody.velocity = new Vector2( _rigidbody.velocity.x, verticalSpeed);
    }

    #endregion

    #region Inputs

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        // jump if on the ground and button pressed
        if (!isGrounded.Value || !context.started) return;

        _rigidbody.velocity = myTransform.up * jumpPower.Value;
        if (resetGroundedCoroutine != null)
        {
            StopCoroutine(resetGroundedCoroutine);
        }
        
        isGrounded.Value = false;
        OnJump.Raise();
    }

    #endregion

    #region Private Methods
    
    private IEnumerator SetGrounded(bool value, float time)
    {
        yield return new WaitForSeconds(time);

        var hit = Physics2D.CircleCast(myTransform.position - myTransform.up * 0.8f, 0.2f, Vector2.down, 0f, 1 << 3);

        isGrounded.Value = value && hit.collider != null;
    }
    
    #endregion
}
