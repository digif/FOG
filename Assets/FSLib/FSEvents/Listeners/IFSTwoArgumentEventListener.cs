using UnityEngine.Events;

namespace FSLib.FSEvents.Listeners
{
    /// <summary>
    /// Interface used for listeners to two arguments FSEventSO
    /// </summary>
    /// <typeparam name="T0"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <inheritdoc/>
    // ReSharper disable once InconsistentNaming
    public abstract class IFsTwoArgumentEventListener<T0, T1> : FsEventListener
    {
        #region Listener Handler
        
        /// <summary>
        /// Method called when FSEventSO raise this listener. It raise the <see cref="UnityEvent"/>
        /// </summary>
        /// <param name="valueOne">the second value to be pass to all subscribers</param>
        /// <param name="valueTwo">the first value to be pass to all subscribers</param>
        protected abstract void Invoke(T0 valueOne, T1 valueTwo);

        #endregion
    }
}