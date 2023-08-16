using UnityEngine;

public class LoseWindow : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        audioSource.Stop();
    }    
}
