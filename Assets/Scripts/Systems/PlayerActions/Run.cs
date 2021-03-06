using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Run : MonoBehaviour
{
    #region Fields
    
    [SerializeField] private Vector2Variable moveDirection = null;
    [SerializeField] private BoolVariable isDead = null;
    [SerializeField] private BoolVariable isGrounded = null;
    [SerializeField] private BoolVariable isMoving = null;
    [SerializeField] private BoolVariable isAgainstWall = null;
    [SerializeField] private BoolVariable isFacingRight = null;
    [SerializeField] private BoolVariable canRun = null;
    [SerializeField] private GameEvent onLevelStarted = null;
    [SerializeField] private Vector2Variable playerSpeed = null;
    
    
    private bool isLevelLoaded = false;
    private float inputValue;
    private Rigidbody2D _rigidbody = null;

    #endregion
    
    #region Unity Event Methods

    private void Awake()
    {
        onLevelStarted.Add(OnLevelStarted);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        onLevelStarted.Remove(OnLevelStarted);
    }
    private void FixedUpdate()
    {
        playerSpeed.Value = _rigidbody.velocity + moveDirection.Value * -inputValue;
        if (!canRun.Value) return;
        if (isAgainstWall.Value) return;
        if (isDead.Value) return;
        if (Math.Abs(inputValue) <= 0.1f)
        {
            isMoving.Value = false;
            return;
        }

        isFacingRight.Value = inputValue > 0;
        isMoving.Value = true;
        
        _rigidbody.position += moveDirection.Value * (-inputValue * Time.deltaTime * 10f * (isGrounded.Value ? 1f : 1f));
        
    }

    #endregion

    #region Inputs

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>().x;
    }

    #endregion

    #region Events

    private void OnLevelStarted ()
    {
        isLevelLoaded = true;
    }

    #endregion
    

    
}