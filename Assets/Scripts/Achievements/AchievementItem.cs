using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    public Image icon;         // Référence à l'image de l'icône
    public TextMeshProUGUI nameText;  // Référence au texte du nom
    public TextMeshProUGUI descriptionText; // Référence au texte de la description

    // Méthode d'initialisation
    public void Initialize(Achievement achievement)
    {
        // Configurer les éléments de l'UI
        icon.sprite = achievement.icon;
        nameText.text = achievement.name;

        if (achievement.isUnlocked)
        {
            descriptionText.text = achievement.description;
            icon.color = Color.white; // Succès débloqué (couleur normale)
        }
        else
        {
            descriptionText.text = "???"; // Texte par défaut pour succès verrouillés
            icon.color = Color.grey; // Rendre l'icône grisée pour indiquer qu'elle est verrouillée
        }

        Debug.Log($"AchievementItem initialisé : {achievement.name}");
    }
}
