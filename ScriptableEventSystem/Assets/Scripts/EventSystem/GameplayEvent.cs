using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableEvents/GameplayEvent")]
public class GameplayEvent : ScriptableObject
{
    private List<GameplayEventListener> _listeners =
        new List<GameplayEventListener>();

    public void Raise()
    {
        for(int i = _listeners.Count -1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameplayEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(GameplayEventListener listener)
    {
        _listeners.Remove(listener);
    }
}
