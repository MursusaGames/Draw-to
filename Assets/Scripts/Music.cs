using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private AudioSource audioSource;
    public static Music instance;
    void Awake()
    {
        if(Music.instance == null)
        {
            Music.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }        
        
    }
    private void OnEnable()
    {
        if (data.isMusic)
        {
            PlayMusic();
        }
        else
        {
            StopMusic();
        }
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
}
