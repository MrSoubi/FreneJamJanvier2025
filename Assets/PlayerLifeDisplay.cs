using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeDisplay : MonoBehaviour
{
    [SerializeField] Image m_Life_1, m_Life_2, m_Life_3;
    [SerializeField] Sprite fullHeart, emptyHeart;

    private void Start()
    {
        m_Life_1.sprite = fullHeart;
        m_Life_2.sprite = fullHeart;
        m_Life_3.sprite = fullHeart;
    }

    public void SetDisplay(int currentHealth)
    {
        m_Life_1.sprite = currentHealth > 0 ? fullHeart : emptyHeart;
        m_Life_2.sprite = currentHealth > 1 ? fullHeart : emptyHeart;
        m_Life_3.sprite = currentHealth > 2 ? fullHeart : emptyHeart;
    }
}
