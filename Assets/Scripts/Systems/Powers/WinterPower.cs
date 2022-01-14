using System.Collections;
using UnityEngine;

public class WinterPower : IPower
{
    private const float UseTime = 5f;
    
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
        
        powerManager.StartCoroutine(Stop(powerManager));
    }

    private IEnumerator Stop(PowerManager powerManager)
    {
        yield return new WaitForSeconds(UseTime);
        
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
        throw new System.NotImplementedException();
    }

    public override void DashStop(PowerManager powerManager)
    {
        throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }

    public override void OnPowerChanged(PowerManager powerManager)
    {
        throw new System.NotImplementedException();
    }
}
