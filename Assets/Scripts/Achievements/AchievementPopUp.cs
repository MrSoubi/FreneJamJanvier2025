using TMPro;
using UnityEngine;

public class AchievementPopUp : MonoBehaviour
{
    public TextMeshProUGUI nameText;  // R�f�rence au texte du nom
    public TextMeshProUGUI descriptionText; // R�f�rence au texte de la description

    // Temps avant de d�truire le GameObject (en secondes)
    public float destroyDelay = 3.0f;

    public void Initialize(Achievement achievement)
    {
        // Configurer les �l�ments de l'UI
        nameText.text = achievement.name;
        descriptionText.text = achievement.description;

        // D�truire le GameObject apr�s le d�lai sp�cifi�
        Destroy(gameObject, destroyDelay);
    }
}
