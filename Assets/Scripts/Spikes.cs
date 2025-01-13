using Unity.VisualScripting;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] float pushForce = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * pushForce);
            Debug.Log("spikes");
        }
    }
}
