using FSLib.FSEvents.SO;
using UnityEngine;
using UnityEngine.Events;

namespace Systems.Events
{
    [System.Serializable]
    public class PowerEvent : UnityEvent<PowerType>
    {
    }
    
    [CreateAssetMenu(fileName = "FSPowerTypeEvent", menuName = "FSEvents/FSPowerTypeEvent", order = 2)]
    public class PowerEventSo : FsOneArgumentEventSo<PowerType>
    {
    }
}