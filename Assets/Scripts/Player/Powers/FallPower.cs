using System.Collections;
using UnityEngine;

public class FallPower : IPower
{
    private BoolVariable isGrounded;
    
    private const float ActionUseTime = 5f;
    private const float DashUseTime = 0.15f;
    private const float DashSpeed = 20f;
    private const float DashCooldown = 0.5f;

    private FallPowerUi ui;
    private bool isUsingPower;
    private bool isUsingDash;
    private bool canDash = true;
    private float lastDashUseTime;

    private Vector2 dashDirection;

    private Coroutine stopCoroutine;
    
    public override void OnStart(PowerManager powerManager)
    {
        PowerType = PowerType.Fall;
        
        ui = powerManager.fallPowerUi;
        isGrounded = powerManager.isGrounded;
        isGrounded.OnValueChange += ResetDashUse;
    }

    public override void OnPowerSelect(PowerManager powerManager)
    {
        var emission = ui.particlesAura.emission;
        emission.enabled = true;
    }

    public override void UseStart(PowerManager powerManager)
    {
        isUsingPower = true;
        var emission = ui.particlesPower.emission;
        emission.enabled = true;
        
        var rotationValue = powerManager.IsFacingRight.Value ? -90 : 90;
        ui.particlesPower.transform.parent.localRotation
            = Quaternion.AngleAxis(rotationValue, Vector3.forward);
        ui.collider.SetActive(true);
    }

    public override void UseStop(PowerManager powerManager)
    {
        ui.collider.SetActive(false);
        isUsingPower = false;
        var emission = ui.particlesPower.emission;
        emission.enabled = false;
        
        ui.collider.SetActive(false);
    }

    private void ResetDashUse()
    {
        if (isGrounded.Value && lastDashUseTime + DashCooldown <= Time.time) canDash = true;
    }

    public override void DashStart(PowerManager powerManager)
    {
        if (!canDash) return;

        canDash = false;
        isUsingDash = true;
        lastDashUseTime = Time.time;

        powerManager.PlayerRigidbody.gravityScale = 0;
        stopCoroutine = powerManager.StartCoroutine(StopDash(powerManager));
        powerManager.StartCoroutine(DashCooldownReset());
        powerManager.PlayerRigidbody.velocity = new Vector2(powerManager.PlayerRigidbody.velocity.x, 0);
        powerManager.CanRun = false;
        
        if (powerManager.MoveInput != Vector2.zero)
        {
            dashDirection = powerManager.MoveInput.normalized;
        }
        else
        {
            dashDirection = powerManager.IsFacingRight.Value ? Vector3.right : Vector3.left;
        }
    }

    private IEnumerator DashCooldownReset()
    {
        yield return new WaitForSeconds(DashCooldown + Time.deltaTime);
        
        ResetDashUse();
    }
    
    private IEnumerator StopDash(PowerManager powerManager)
    {
        yield return new WaitForSecondsRealtime(DashUseTime);
        
        DashStop(powerManager);
    }
    
    public override void DashStop(PowerManager powerManager)
    {
        if (!(stopCoroutine is null)) powerManager.StopCoroutine(stopCoroutine);

        powerManager.PlayerRigidbody.gravityScale = 8;
        isUsingDash = false;
        powerManager.CanRun = true;
    }

    public override void OnUpdate(PowerManager powerManager)
    {
        if (!isUsingPower) return;

        //TODO change this to use IsFacingRight.OnValueCHanged
        var rotationValue = powerManager.IsFacingRight.Value ? -90 : 90;
        ui.particlesPower.transform.parent.localRotation
            = Quaternion.AngleAxis(rotationValue, Vector3.forward);
    }

    public override void OnLateUpdate(PowerManager powerManager)
    {
        if (isUsingDash)
        {
            powerManager.PlayerRigidbody.position += dashDirection * (DashSpeed * Time.deltaTime);
        }
    }

    public override void OnPowerChanged(PowerManager powerManager)
    {
        var emission = ui.particlesAura.emission;
        emission.enabled = false;
    }
}