using UnityEngine;
using UnityEngine.Events;

public class GameplayEventListener : MonoBehaviour
{
    public GameplayEvent _gameplayEvent;
    public UnityEvent _response;

    private void OnEnable()
    {
        _gameplayEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        _gameplayEvent.UnregisterListener(this);
    }

    private void OnDestroy()
    {
        _gameplayEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        _response.Invoke();
    }
}
