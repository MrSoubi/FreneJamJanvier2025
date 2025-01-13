using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform target; // La cible que la caméra doit suivre
    public Vector3 offset; // Décalage par rapport à la cible

    public IEnumerator Shake(float duration, float magnitude)
    {
        // Enregistre la position initiale de la caméra
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Génère un décalage aléatoire dans un cercle de rayon "magnitude"
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            // Applique le décalage à la position de la cible suivie
            if (target != null)
            {
                transform.position = target.position + offset + new Vector3(offsetX, offsetY, 0);
            }

            elapsed += Time.deltaTime;

            yield return null; // Attend le prochain frame
        }

        // Remet la caméra à la position relative à la cible
        if (target != null)
        {
            transform.position = target.position + offset;
        }
        else
        {
            transform.localPosition = originalPosition;
        }
    }
}
