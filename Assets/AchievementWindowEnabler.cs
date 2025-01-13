using UnityEngine;

public class AchievementWindowEnabler : MonoBehaviour
{
    public GameObject achievementGrid;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            achievementGrid.SetActive(!achievementGrid.activeSelf);
            Time.timeScale = Mathf.Abs(Time.timeScale - 1);
        }
    }
}
