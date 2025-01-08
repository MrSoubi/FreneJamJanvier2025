using UnityEngine;
using System.Collections;

public class Bomb : Interactable
{
    private bool isLit = false;
    public float explosionDelay = 3f; // Temps avant explosion en secondes
    public GameObject explosionEffect; // Effet d'explosion (optionnel)
    [SerializeField] HurtBox m_HurtBox;

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
        Debug.Log("Bombe allum�e ! Compte � rebours lanc�...");
        yield return new WaitForSeconds(explosionDelay);

        Explode();
    }

    private void Explode()
    {
        Debug.Log("BOOM ! La bombe a explos�.");

        // Ajouter ici la logique d'explosion
        // Par exemple : instancier un effet visuel d'explosion
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        m_HurtBox.ApplyDamage();

        // Supprimer ou d�sactiver la bombe apr�s l'explosion
        Destroy(gameObject);
    }
}