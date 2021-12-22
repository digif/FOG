using System;
using FSLib.FSEvents.Listeners;
using UnityEngine;

namespace FSLib.FSEvents.SO
{
    /// <summary>
    /// Scriptable object that contains an action that trigger all <see cref="FsEventListener"/> that subscribe to it.
    /// </summary>
    [CreateAssetMenu(fileName = "FSVoidEvent", menuName = "FSEvents/FSVoidEvent", order = 1)]
    public class FsVoidEventSo : ScriptableObject
    {
        /// <value> The action that trigger all <see cref="FsEventListener"/> that registered</value>
        public Action fsVoidEvent;

        #region Listener Handler

        /// <summary>
        /// Function called by original raiser of the event.
        /// </summary>
        public void Invoke()
        {
            fsVoidEvent?.Invoke();
        }

        #endregion
    }
}