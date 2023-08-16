using UnityEngine;

public class SoundBtn : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private AudioSource audioSource;
    public void PlayClick()
    {
        if (data.isSound)
            audioSource.Play();
    }
}
