using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

public class PowerManager : MonoBehaviour
{
    #region Fields

    public Rigidbody2D PlayerRigidbody;
    public Transform PlayerTransform;
    public BoolVariable IsFacingRight;
    
    public WinterPowerUi winterPowerUi;
    public FallPowerUi fallPowerUi;
    
    private readonly FallPower fallPower = new FallPower();
    private readonly WinterPower winterPower = new WinterPower();
    //TODO add other powers

    [SerializeField] private BoolVariable canRun = null;
    [SerializeField] private Vector2Variable moveDirection = null;
    private Vector2 moveInput;

    private IPower currentPower;

    #endregion

    #region Properties

    public Vector2 MoveDirection => moveDirection.Value;
    public Vector2 MoveInput => moveInput;
    public Vector2 InputValue { get; private set; }
    
    public bool CanRun { set => canRun.Value = value; }

    #endregion

    #region Inputs
    
    [UsedImplicitly]
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        print(moveInput);
    }
    
    [UsedImplicitly]
    public void OnAimInput(InputAction.CallbackContext context)
    {
        InputValue = context.ReadValue<Vector2>();
    }

    [UsedImplicitly]
    public void OnPowerWinter(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (currentPower == winterPower) return;
            
        currentPower?.OnPowerChanged(this);
        currentPower = winterPower;
        currentPower.OnPowerSelect(this);
    }
    
    [UsedImplicitly]
    public void OnPowerFall(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (currentPower == fallPower) return;
            
        currentPower?.OnPowerChanged(this);
        currentPower = fallPower;
        currentPower.OnPowerSelect(this);
    }

    [UsedImplicitly]
    public void OnPowerAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentPower?.UseStart(this);
        }
        else if (context.canceled)
        {
            currentPower?.UseStop(this);
        }
    }
    
    [UsedImplicitly]
    public void OnDashAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentPower?.DashStart(this);
        }
        else if (context.canceled)
        {
            currentPower?.DashStop(this);
        }
    }

    [UsedImplicitly]
    public void OnJumpAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentPower?.DashStop(this);
        }
    }
    
    #endregion

    #region Unity Event Methods

    private void Awake()
    {
        CanRun = true;
        fallPower.OnStart(this);
        winterPower.OnStart(this);
    }

    private void Update()
    {
        currentPower?.OnUpdate(this);
    }

    #endregion
}
