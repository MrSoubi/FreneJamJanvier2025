using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public List<Achievement> achievements; // Liste de tous les succès

    [SerializeField] GameObject achievementPopUpPrefab;
    [SerializeField] GameObject achievementPopUpContainer;


    void Start()
    {
        foreach (var achievement in achievements)
        {
            // Initialiser tous les succès comme verrouillés
            achievement.isUnlocked = false;

            // Gérer les RSO
            if (achievement.reactiveSO is IReactiveSO<int> intSO)
            {
                intSO.onValueChanged += (value) =>
                {
                    CheckAchievement(achievement, value);
                };
            }
            else if (achievement.reactiveSO is IReactiveSO<float> floatSO)
            {
                floatSO.onValueChanged += (value) =>
                {
                    CheckAchievement(achievement, value);
                };
            }

            // Gérer les RSE
            if (achievement.reactiveSE is IReactiveSE reactiveSE)
            {
                reactiveSE.TriggerEvent += () =>
                {
                    UnlockAchievement(achievement);
                };
            }
        }
    }

    private void CheckAchievement(Achievement achievement, float currentValue)
    {
        if (!achievement.isUnlocked && currentValue >= achievement.targetValue)
        {
            UnlockAchievement(achievement);
        }
    }

    private void UnlockAchievement(Achievement achievement)
    {
        if (achievement.isUnlocked) return;

        achievement.isUnlocked = true;
        Debug.Log($"Succès débloqué : {achievement.name}");
        ShowAchievementPopup(achievement);
    }

    private void ShowAchievementPopup(Achievement achievement)
    {
        GameObject newPopUp = Instantiate(achievementPopUpPrefab, achievementPopUpContainer.transform);

        newPopUp.GetComponent<AchievementPopUp>().Initialize(achievement);
    }
}
