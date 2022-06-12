using UnityEngine;
using System;

[CreateAssetMenu(menuName = "PrimitiveTypes/Float")]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{

    public float initialValue;

    [NonSerialized]
    public float runtimeValue;


    public void OnAfterDeserialize()
    {
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize() { }
}
