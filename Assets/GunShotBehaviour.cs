using UnityEngine;

public class GunShotBehaviour : MonoBehaviour
{
    public AudioSource m_AudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_AudioSource.pitch = Random.Range(0.9f, 1.1f);
        m_AudioSource.Play();
    }
}
