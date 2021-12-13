using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable/Event")]
public class GameEvent : ScriptableObject
{
    private UnityAction _listeners = null;
    
    // raise event
    public void Raise() { if(_listeners != null) _listeners(); }

    // Add a listener to the event
    public void Add(UnityAction listener) { _listeners += listener; }

    //remove a listener from the event
    public void Remove(UnityAction listener) { _listeners -= listener; }
}