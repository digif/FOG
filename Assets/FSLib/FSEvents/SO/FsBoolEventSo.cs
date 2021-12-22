using UnityEngine;
using UnityEngine.Events;

namespace FSLib.FSEvents.SO
{
    /// <summary>
    /// Implementation of <see cref="UnityEvent"/> used in <see cref="FsBoolEventSo"/>
    /// </summary>
    [System.Serializable]
    public class FsBoolEvent : UnityEvent<bool>
    {
    }
    
    /// <inheritdoc cref="FsOneArgumentEventSo{T}"/>
    [CreateAssetMenu(fileName = "FSBoolEvent", menuName = "FSEvents/FSBoolEvent", order = 2)]
    public class FsBoolEventSo : FsOneArgumentEventSo<bool>
    {
    }
}