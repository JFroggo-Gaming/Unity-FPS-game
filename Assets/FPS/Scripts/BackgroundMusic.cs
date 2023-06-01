using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
