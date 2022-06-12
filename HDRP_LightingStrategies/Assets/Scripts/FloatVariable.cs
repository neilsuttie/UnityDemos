using UnityEngine;
using System;

[CreateAssetMenu(menuName = "PrimitiveTypes/Float")]
public class FloatVariable : ScriptableObject,
    ISerializationCallbackReceiver
{

    public float _initialValue;

    [NonSerialized]
    public float _runtimeValue;

    public void OnAfterDeserialize()
    {
        _runtimeValue = _initialValue;
    }

    public void OnBeforeSerialize() {  }
}
