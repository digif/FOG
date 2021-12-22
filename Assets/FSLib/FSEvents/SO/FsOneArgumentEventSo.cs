using System;
using FSLib.FSEvents.Listeners;
using UnityEngine;

namespace FSLib.FSEvents.SO
{
    /// <summary>
    /// Scriptable object that contains an action that trigger all <see cref="FsEventListener"/> that subscribe to it.
    /// </summary>
    public class FsOneArgumentEventSo<T> : ScriptableObject
    {
        /// <value> The action that trigger all <see cref="FsEventListener"/> that registered</value>
        public Action<T> fsOneArgumentAction;
        
        /// <summary>
        /// Function called by original raiser of the event.
        /// </summary>
        /// <param name="value"> the value to be raised</param>
        public void Invoke(T value)
        {
            fsOneArgumentAction?.Invoke(value);
        }
    }
}