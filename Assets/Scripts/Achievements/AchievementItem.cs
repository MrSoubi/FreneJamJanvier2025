using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementItem : MonoBehaviour
{
    public Image icon;         // R�f�rence � l'image de l'ic�ne
    public TextMeshProUGUI nameText;  // R�f�rence au texte du nom
    public TextMeshProUGUI descriptionText; // R�f�rence au texte de la description

    // M�thode d'initialisation
    public void Initialize(Achievement achievement)
    {
        // Configurer les �l�ments de l'UI
        icon.sprite = achievement.icon;
        nameText.text = achievement.name;

        if (achievement.isUnlocked)
        {
            descriptionText.text = achievement.description;
            icon.color = Color.white; // Succ�s d�bloqu� (couleur normale)
        }
        else
        {
            descriptionText.text = "???"; // Texte par d�faut pour succ�s verrouill�s
            icon.color = Color.grey; // Rendre l'ic�ne gris�e pour indiquer qu'elle est verrouill�e
        }

        Debug.Log($"AchievementItem initialis� : {achievement.name}");
    }
}
