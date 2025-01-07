using UnityEngine;

public class PointTowardsMouse : MonoBehaviour
{
    void Update()
    {
        // Obtenir la position de la souris en coordonnées du monde
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculer la direction entre le GameObject et la position de la souris
        Vector2 direction = (Vector2)(mousePosition - transform.position);

        // Calculer l'angle en degrés
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Appliquer la rotation au GameObject
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
