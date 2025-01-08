using UnityEngine;

[CreateAssetMenu(fileName = "NewAchievement", menuName = "Achievements/Achievement")]
public class Achievement : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite icon;
    public bool isUnlocked = false;

    // Références abstraites
    public ScriptableObject reactiveSO; // RSO (int ou float)
    public ScriptableObject reactiveSE; // RSE (événements déclenchés)

    // Condition pour les RSO
    public float targetValue; // Valeur cible
}