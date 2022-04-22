public abstract class IPower
{
    private const float cooldown = 1f;
    private float _lastPowerUse = 0;
    private float _lastDashUse = 0;

    public abstract void OnStart(PowerManager powerManager);
    public abstract void OnPowerSelect(PowerManager powerManager);
    public abstract void UseStart(PowerManager powerManager);
    public abstract void UseStop(PowerManager powerManager);
    public abstract void DashStart(PowerManager powerManager);
    public abstract void DashStop(PowerManager powerManager);
    public abstract void OnUpdate(PowerManager powerManager);
    public abstract void OnLateUpdate(PowerManager powerManager);
    public abstract void OnPowerChanged(PowerManager powerManager);
}
