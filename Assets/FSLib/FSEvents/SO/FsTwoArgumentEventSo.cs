using System;
using FSLib.FSEvents.Listeners;
using UnityEngine;

namespace FSLib.FSEvents.SO
{
    public class FsTwoArgumentEventSo<T0, T1> : ScriptableObject
    {
        /// <value> The action that trigger all <see cref="FsEventListener"/> that registered</value>
        public Action<T0, T1> fsTwoArgumentAction;
        
        /// <summary>
        /// Function called by original raiser of the event.
        /// </summary>
        /// <param name="valueOne"> the firs value to be raised</param>
        /// <param name="valueTwo"> the second value to be raised</param>
        public void Invoke(T0 valueOne, T1 valueTwo)
        {
            fsTwoArgumentAction?.Invoke(valueOne, valueTwo);
        }
    }
}