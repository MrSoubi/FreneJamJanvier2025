using UnityEngine;
using System.Collections;

public class Bomb : Interactable
{
    public RSE_BombInteraction bombInteraction;
    public RSO_BombCount bombCount;

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

    public SpriteRenderer spriteRenderer;
    public float initialFlashDuration = 0.5f; // Dur�e du premier flash
    public float reductionFlashDuration = 0.08f; // Dur�e du dernier flash

    private IEnumerator ExplodeAfterDelay()
    {
        Debug.Log("Bombe allum�e ! Compte � rebours lanc�...");

        float elapsedTime = 0f;
        float flashDuration = initialFlashDuration;

        while (elapsedTime < explosionDelay)
        {
            // Alterner entre la couleur blanche et la couleur originale
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(flashDuration / 4);

            spriteRenderer.color = Color.white; // Remplacer par la couleur d'origine si besoin
            yield return new WaitForSeconds(flashDuration / 4 * 3);

            // R�duire progressivement la dur�e des flashs
            flashDuration = Mathf.Clamp(flashDuration - reductionFlashDuration, 0.05f, Mathf.Infinity);

            elapsedTime += flashDuration;
        }

        Explode();
    }



    public void Explode()
    {
        bombInteraction?.FireEvent();
        bombCount.Value++;

        // Ajouter ici la logique d'explosion
        // Par exemple : instancier un effet visuel d'explosion
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position + Vector3.down / 2, Quaternion.identity);
        }

        m_HurtBox.ApplyDamage();

        // Supprimer ou d�sactiver la bombe apr�s l'explosion
        Destroy(gameObject);
    }
}