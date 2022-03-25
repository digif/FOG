using System.Collections;
using DG.Tweening;
using UnityEngine;

public class FallPower : IPower
{
    private const float ActionUseTime = 5f;
    private const float DashUseTime = 0.15f;
    private const float DashSpeed = 50f;
    
    private FallPowerUi ui;
    private bool isUsingPower;
    private bool isUsingDash;

    private Coroutine stopCoroutine;
    
    public override void OnStart(PowerManager powerManager)
    {
        ui = powerManager.fallPowerUi;
    }

    public override void OnPowerSelect(PowerManager powerManager)
    {
        var emission = ui.particlesAura.emission;
        emission.enabled = true;
    }

    public override void UseStart(PowerManager powerManager)
    {
        //TODO stop player movements
        //TODO Show Ui
    }

    public override void UseStop(PowerManager powerManager)
    {
        //TODO Allow player to move
        //TODO Hide Ui
    }

    public override void DashStart(PowerManager powerManager)
    {
        isUsingDash = true;

        powerManager.PlayerRigidbody.gravityScale = 0;
        stopCoroutine = powerManager.StartCoroutine(StopDash(powerManager));
    }
    
    private IEnumerator StopDash(PowerManager powerManager)
    {
        Debug.Log(DashUseTime);
        yield return new WaitForSecondsRealtime(DashUseTime);
        
        DashStop(powerManager);
    }
    
    public override void DashStop(PowerManager powerManager)
    {
        if (!(stopCoroutine is null)) powerManager.StopCoroutine(stopCoroutine);

        powerManager.PlayerRigidbody.gravityScale = 8;
        isUsingDash = false;
    }

    public override void OnUpdate(PowerManager powerManager)
    {
        if (isUsingPower)
        {
            //TODO Implement fall power
        }
        else if (isUsingDash)
        {
            var playerTransform = powerManager.PlayerTransform;

            playerTransform.position += playerTransform.right *
                                        ((powerManager.IsFacingRight.Value ? 1 : -1) * DashSpeed * Time.deltaTime);
        }
    }

    public override void OnPowerChanged(PowerManager powerManager)
    {
        var emission = ui.particlesAura.emission;
        emission.enabled = false;
    }
}
