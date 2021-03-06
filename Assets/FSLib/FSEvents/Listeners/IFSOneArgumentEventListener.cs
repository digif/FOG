using UnityEngine.Events;

namespace FSLib.FSEvents.Listeners
{
    /// <summary>
    /// Interface used for listeners to one arguments FSEventSO
    /// </summary>
    /// <typeparam name="T"> the type of the event to witch we register</typeparam>
    /// <inheritdoc/>
    
    // ReSharper disable once InconsistentNaming
    public abstract class IFsOneArgumentEventListener<T> : FsEventListener
    {
        #region Listener Handler

        /// <summary>
        /// Method called when FSEventSO raise this listener. It raise the <see cref="UnityEvent"/>
        /// </summary>
        /// <param name="value">the value to be pass to all subscribers</param>
        protected abstract void Invoke(T value);

        #endregion
    }
}