using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventData : ScriptableObject
{
    [SerializeField] private string eventName = null;

    public string GetName() => eventName;
}
