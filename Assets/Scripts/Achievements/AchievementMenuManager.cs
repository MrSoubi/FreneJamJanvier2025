using System.Collections.Generic;
using UnityEngine;

public class AchievementMenuManager : MonoBehaviour
{
    public RectTransform gridParent; // Le parent de la grille (Panel avec Grid Layout Group)
    public GameObject achievementItemPrefab; // Le prefab pour un item d'achievement

    public List<Achievement> achievements; // Liste des achievements (remplie dans l'inspecteur)

    private void OnEnable()
    {
        PopulateGrid();
    }

    void PopulateGrid()
    {
        foreach (RectTransform child in gridParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var achievement in achievements)
        {
            // Instancier un prefab pour chaque achievement
            GameObject item = Instantiate(achievementItemPrefab, gridParent);

            // Initialiser l'item via son script
            AchievementItem itemScript = item.GetComponent<AchievementItem>();

            if (itemScript == null)
            {
                Debug.LogError("Le prefab n'a pas de script AchievementItem configuré !");
                continue;
            }

            // Appeler la méthode d'initialisation
            itemScript.Initialize(achievement);
        }
    }
}
