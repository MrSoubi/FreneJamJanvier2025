using UnityEngine;

public class Door : Interactable
{
    public RSE_DoorInteraction doorInteraction;

    public override void Interact()
    {
        doorInteraction.TriggerEvent?.Invoke();
        Destroy(gameObject);
    }
}