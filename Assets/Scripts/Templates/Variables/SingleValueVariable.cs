using UnityEngine;

public class SingleValueVariable<T> : ScriptableObject
{
    [SerializeField]
    private T _value;
    public T Value { get => _value; set => _value = value; }
}