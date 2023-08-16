using UnityEngine;
using TMPro;

public class UISystem : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject skinsWindow;
    [SerializeField] private SoundSystem soundSystem;
    [SerializeField] private MatchData data;
    [SerializeField] private TextMeshProUGUI levelValue;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI keyValue;

    public void ShowSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }
    public void HideSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void ShowSkinsWindow()
    {
        skinsWindow.SetActive(true);
    }
    public void HideSkinsWindow()
    {
        skinsWindow.SetActive(false);
    }
    public void ChangeSound()
    {
        data.isSound = !data.isSound;
        Invoke(nameof(Save), 0.1f);
    }

    private void Save()
    {
        if (data.isSound)
        {
            soundSystem.OnSound();
            PlayerPrefs.SetInt("Sound", 1);            
        }
        else
        {
            soundSystem.OffSound();
            PlayerPrefs.SetInt("Sound", 0);           
        }
            
    }
    public void ChangeMusic()
    {
        data.isMusic = !data.isMusic;
        Invoke(nameof(SaveMusic), 0.1f);
    }
    private void SaveMusic()
    {
        if (data.isMusic)
        {
            Music.instance.PlayMusic();
            soundSystem.SetMusic(true);
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            Music.instance.StopMusic();
            soundSystem.SetMusic(false);
            PlayerPrefs.SetInt("Music", 0);
        }

    }
    public void ChangeVibrations()
    {
        data.isVibration = !data.isVibration;
        Invoke(nameof(SaveVibration), 0.1f);
    }
    private void SaveVibration()
    {
        if (data.isVibration)
        {
            soundSystem.SetVibration(true);
            PlayerPrefs.SetInt("Vibration", 1);
        }
        else
        {
            soundSystem.SetVibration(false);
            PlayerPrefs.SetInt("Vibration", 0);
        }

    }
    public void ChangeUI()
    {
        levelValue.text = data.level.ToString();
        scoreValue.text = data.score.ToString();
        keyValue.text = data.keys.ToString();
    }
}
