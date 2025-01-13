using UnityEngine;
using System.Collections;

public class Bomb : Interactable
{
    public RSE_BombInteraction bombInteraction;

    private bool isLit = false;
    public float explosionDelay = 3f; // Temps avant explosion en secondes
    public GameObject explosionEffect; // Effet d'explosion (optionnel)
    [SerializeField] HitBox m_HurtBox;

    public override void Interact()
    {
        if (!isLit)
        {
            isLit = true;
            StartCoroutine(ExplodeAfterDelay());
        }
    }

    private IEnumerator ExplodeAfterDelay()
    {
        Debug.Log("Bombe allumée ! Compte à rebours lancé...");
        yield return new WaitForSeconds(explosionDelay);

        Explode();
    }

    private void Explode()
    {
        bombInteraction?.FireEvent();

        // Ajouter ici la logique d'explosion
        // Par exemple : instancier un effet visuel d'explosion
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        m_HurtBox.ApplyDamage();

        // Supprimer ou désactiver la bombe après l'explosion
        Destroy(gameObject);
    }
}