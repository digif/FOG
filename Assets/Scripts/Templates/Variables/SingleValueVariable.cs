using System;
using UnityEngine;

public class SingleValueVariable<T> : ScriptableObject
{
    [SerializeField]
    private T _value;

    public Action OnValueChange;
    
    public T Value
    {
        get => _value;
        set
        {
            if (value.Equals(_value)) return;
            
            _value = value;
            OnValueChange?.Invoke();
        }
    }
}