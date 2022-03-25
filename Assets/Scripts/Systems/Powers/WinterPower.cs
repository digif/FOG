using System.Collections;
using DG.Tweening;
using UnityEngine;

public class WinterPower : IPower
{
    private const float ActionUseTime = 5f;
    private const float DashUseTime = 5f;
    
    private WinterPowerUi ui;
    private bool isUsingPower;
    private bool isUsingDash;
    private Rigidbody2D playerRigidbody2D;

    private Tween rotationTween;
    private Coroutine stopCoroutine;
    
    public override void OnStart(PowerManager powerManager)
    {
        playerRigidbody2D = powerManager.PlayerTransform.GetComponent<Rigidbody2D>();
        ui = powerManager.winterPowerUi;
    }

    public override void OnPowerSelect(PowerManager powerManager)
    {
        //TODO activate aura of the power
        //TODO anim start
    }

    public override void UseStart(PowerManager powerManager)
    {
        isUsingPower = true;
        ui.ui.SetActive(true);
        var emission = ui.particlesPower.emission;
        emission.enabled = true;
        
        var rotationValue = ui.isFacingRight.Value ? -90 : 90;
        ui.uiAim.transform.localRotation 
            = Quaternion.AngleAxis(rotationValue, Vector3.forward);
        ui.particlesPower.transform.parent.localRotation
            = Quaternion.AngleAxis(rotationValue, Vector3.forward);
        
        powerManager.StartCoroutine(StopAction(powerManager));
    }

    private IEnumerator StopAction(PowerManager powerManager)
    {
        yield return new WaitForSeconds(ActionUseTime);
        
        isUsingPower = false;
        ui.ui.SetActive(false);
        var emission = ui.particlesPower.emission;
        emission.enabled = false;
    }
    
    public override void UseStop(PowerManager powerManager)
    {
    }

    public override void DashStart(PowerManager powerManager)
    {
        isUsingDash = true;

        powerManager.PlayerRigidbody.gravityScale = 0;
        stopCoroutine = powerManager.StartCoroutine(StopDash(powerManager));
    }

    private IEnumerator StopDash(PowerManager powerManager)
    {
        yield return new WaitForSeconds(DashUseTime);
        
        DashStop(powerManager);
    }
    
    public override void DashStop(PowerManager powerManager)
    {
        if (!(stopCoroutine is null)) powerManager.StopCoroutine(stopCoroutine);

        powerManager.PlayerRigidbody.gravityScale = 8;
        isUsingDash = false;
        ui.ui.SetActive(false);
        var emission = ui.particlesPower.emission;
        emission.enabled = false;
        rotationTween?.Kill();
        rotationTween = DOTween.To(() => powerManager.PlayerTransform.right, x => powerManager.PlayerTransform.right = x, Vector3.right, 0.1f);
    }

    public override void OnUpdate(PowerManager powerManager)
    {
        if (isUsingPower)
        {
            if (powerManager.InputValue == Vector2.zero) return;
            
            var rotationValue = -Vector2.SignedAngle(powerManager.InputValue, Vector2.up);

            ui.uiAim.transform.localRotation 
                = Quaternion.AngleAxis(rotationValue, Vector3.forward);
            ui.particlesPower.transform.parent.localRotation
                = Quaternion.AngleAxis(rotationValue, Vector3.forward);
        }
        else if (isUsingDash)
        {
            Vector2 moveDirection;
            var playerTransform = powerManager.PlayerTransform;
            var position = playerTransform.position;

            playerRigidbody2D.velocity = Vector2.zero;

            const int layer = 1 << 3;
            var playerRight = playerTransform.right;
            var playerUp = playerTransform.up;
            var hit = Physics2D.Raycast(position + playerRight * 0.15f, -playerUp, 1.5f, layer);
            Debug.DrawRay(position + playerRight * 0.3f, -playerUp * 1.5f, Color.black);
            
            if (hit.collider != null)
            {
                moveDirection = -Vector2.Perpendicular(hit.normal).normalized;
            }
            else
            {
                DashStop(powerManager);
                return;
            }

            var angle = Vector3.SignedAngle(playerRight, moveDirection, Vector3.forward);
            rotationTween?.Kill();
            rotationTween = playerTransform.DORotate(playerTransform.eulerAngles + new Vector3(0, 0, angle), 0.1f);
            
            position += new Vector3(moveDirection.x, moveDirection.y, 0) * (Time.deltaTime * 10f * (powerManager.IsFacingRight.Value ? 1f : -1f));
            playerTransform.position = position;
            if (angle != 0) Debug.Log(angle);
        }
    }

    public override void OnPowerChanged(PowerManager powerManager)
    {
        //TODO activate aura of the power
        //TODO anim start
    }
}
