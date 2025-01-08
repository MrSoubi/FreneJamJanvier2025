using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerEnterEvent : UnityEvent<Transform> { }

[System.Serializable]
public class PlayerExitEvent : UnityEvent { }

public class PlayerDetector : MonoBehaviour
{
    [Header("Event triggered when Player enters trigger")]
    public PlayerEnterEvent OnPlayerEnter;

    [Header("Event triggered when Player exits trigger")]
    public PlayerExitEvent OnPlayerExit;

    // This method is called when another collider enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Invoke the UnityEvent and pass the player's transform
            OnPlayerEnter?.Invoke(other.transform);
        }
    }

    // This method is called when another collider exits the trigger collider
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Invoke the UnityEvent and pass the player's transform
            OnPlayerExit?.Invoke();
        }
    }
}