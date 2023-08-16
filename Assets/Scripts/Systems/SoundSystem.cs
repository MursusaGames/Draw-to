using UnityEngine;
using UnityEngine.UI;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;
    public GameObject redSoundToggle;
    public GameObject greenSoundToggle;
    public GameObject redMusicToggle;
    public GameObject greenMusicToggle;
    public GameObject redVibrationToggle;
    public GameObject greenVibrationToggle;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnSound()
    {
        redSoundToggle.SetActive(false);
        greenSoundToggle.SetActive(true);
    }
    public void OffSound()
    {
        redSoundToggle.SetActive(true);
        greenSoundToggle.SetActive(false);
    }

    public void SetMusic(bool on)
    {
        if (on)
        {
            redMusicToggle.SetActive(false);
            greenMusicToggle.SetActive(true);
        }
        else
        {
            redMusicToggle.SetActive(true);
            greenMusicToggle.SetActive(false);
        }
    }
    public void SetVibration(bool on)
    {
        if (on)
        {
            redVibrationToggle.SetActive(false);
            greenVibrationToggle.SetActive(true);
        }
        else
        {
            redVibrationToggle.SetActive(true);
            greenVibrationToggle.SetActive(false);
        }
    }

    public void PlaySound()
    {
        if(data.isSound) 
            audioSource.Play();
    }
}
