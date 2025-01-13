using TMPro;
using UnityEngine;

public class AchievementPopUp : MonoBehaviour
{
    public TextMeshProUGUI nameText;  // Référence au texte du nom
    public TextMeshProUGUI descriptionText; // Référence au texte de la description

    // Temps avant de détruire le GameObject (en secondes)
    public float destroyDelay = 3.0f;

    public void Initialize(Achievement achievement)
    {
        // Configurer les éléments de l'UI
        nameText.text = achievement.name;
        descriptionText.text = achievement.description;

        // Détruire le GameObject après le délai spécifié
        Destroy(gameObject, destroyDelay);
    }
}
