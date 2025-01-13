using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public List<Achievement> achievements; // Liste de tous les succ�s

    [SerializeField] GameObject achievementPopUpPrefab;
    [SerializeField] GameObject achievementPopUpContainer;


    void Start()
    {
        foreach (var achievement in achievements)
        {
            // Initialiser tous les succ�s comme verrouill�s
            achievement.isUnlocked = false;

            // G�rer les RSO
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

            // G�rer les RSE
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
        Debug.Log($"Succ�s d�bloqu� : {achievement.name}");
        ShowAchievementPopup(achievement);
    }

    private void ShowAchievementPopup(Achievement achievement)
    {
        GameObject newPopUp = Instantiate(achievementPopUpPrefab, achievementPopUpContainer.transform);

        newPopUp.GetComponent<AchievementPopUp>().Initialize(achievement);
    }
}
