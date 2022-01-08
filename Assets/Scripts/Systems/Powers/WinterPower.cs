using UnityEngine;

public class WinterPower : IPower
{
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
        powerManager.CanRun = false;
        ui.ui.SetActive(true);
        var emission = ui.particlesPower.emission;
        Debug.Log(emission.enabled);
        emission.enabled = true;
    }

    public override void UseStop(PowerManager powerManager)
    {
        isUsingPower = false;
        powerManager.CanRun = true;
        ui.ui.SetActive(false);
        var emission = ui.particlesPower.emission;
        emission.enabled = false;
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
            ui.uiAim.transform.localRotation 
                *= Quaternion.AngleAxis(-powerManager.InputValue * Time.deltaTime * 100f, Vector3.forward);
            ui.particlesPower.transform.parent.localRotation
                *= Quaternion.AngleAxis(-powerManager.InputValue * Time.deltaTime * 100f, Vector3.forward);
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
