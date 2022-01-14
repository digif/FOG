using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WinterPower : IPower
{
    private const float ActionUseTime = 5f;
    private const float DashUseTime = 5f;
    
    private WinterPowerUi ui;
    private bool isUsingPower;
    private bool isUsingDash;
    
    public override void OnStart(PowerManager powerManager)
    {
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
        ;
    }

    public override void DashStart(PowerManager powerManager)
    {
        isUsingDash = true;
        // var emission = ui.particlesPower.emission;
        // emission.enabled = true;
        
        powerManager.StartCoroutine(StopDash());
    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(DashUseTime);
        
        isUsingDash = false;
        ui.ui.SetActive(false);
        var emission = ui.particlesPower.emission;
        emission.enabled = false;
    }
    
    public override void DashStop(PowerManager powerManager)
    {
        isUsingDash = false;
        ui.ui.SetActive(false);
        var emission = ui.particlesPower.emission;
        emission.enabled = false;
        powerManager.PlayerTransform.right = Vector3.right;
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
            var moveDirection = -powerManager.MoveDirection;
            var playerTransform = powerManager.PlayerTransform;
            var position = playerTransform.position;

            playerTransform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            const int layer = 1 << 3;
            var right = playerTransform.right;
            var hit = Physics2D.Raycast(position + right * 0.3f, -playerTransform.up, 1.5f, layer);
            
            Debug.DrawRay(position + right * 0.3f, -playerTransform.up * 1.5f, Color.blue);
            
            if (hit.collider != null)
            {
                Debug.DrawRay(hit.point, hit.normal, Color.magenta);
                moveDirection = -Vector2.Perpendicular(hit.normal).normalized;
                Debug.DrawRay(hit.point, moveDirection, Color.magenta);
            }
            else
            {
                //TODO stop
            }
            
            right = moveDirection;
            playerTransform.right = right;

            // playerTransform.localRotation = Quaternion.AngleAxis(rotationValue, Vector3.forward);
            position += new Vector3(moveDirection.x, moveDirection.y, 0) * Time.deltaTime * 10f;
            playerTransform.position = position;
        }
    }

    public override void OnPowerChanged(PowerManager powerManager)
    {
        throw new System.NotImplementedException();
    }
}
