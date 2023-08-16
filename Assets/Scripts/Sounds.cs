using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        if (data.isSound)
            audioSource.Play();
    }    
}
