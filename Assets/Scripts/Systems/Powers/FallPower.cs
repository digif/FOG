public class FallPower : IPower
{
    public override void OnStart(PowerManager powerManager)
    {
        
    }

    public override void OnPowerSelect(PowerManager powerManager)
    {
        //TODO show aura
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
        throw new System.NotImplementedException();
    }

    public override void DashStop(PowerManager powerManager)
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate(PowerManager powerManager)
    {
        throw new System.NotImplementedException();
    }

    public override void OnPowerChanged(PowerManager powerManager)
    {
        //TODO stop aura
    }
}
