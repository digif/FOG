using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerManager : MonoBehaviour
{
    #region Fields

    public WinterPowerUi winterPowerUi;
    
    private readonly FallPower fallPower = new FallPower();
    private readonly WinterPower winterPower = new WinterPower();
    //TODO add other powers

    [SerializeField] private BoolVariable canRun = null;

    private IPower currentPower;

    #endregion

    #region Properties

    public float InputValue { get; private set; }
    
    public bool CanRun { set => canRun.Value = value; }

    #endregion

    #region Inputs

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        InputValue = context.ReadValue<float>();
    }

    public void OnPowerWinter(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (currentPower == winterPower) return;
            
        currentPower?.OnPowerChanged(this);
        currentPower = winterPower;
        currentPower.OnPowerSelect(this);
    }

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
