using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject achievementGrid;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            achievementGrid.SetActive(!achievementGrid.activeSelf);
        }
    }
}
