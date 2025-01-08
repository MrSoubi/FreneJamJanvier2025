using UnityEngine;

public class SpawnedObjectTracker : MonoBehaviour
{
    public System.Action OnObjectDestroyed;

    private void OnDestroy()
    {
        OnObjectDestroyed?.Invoke();
    }
}
