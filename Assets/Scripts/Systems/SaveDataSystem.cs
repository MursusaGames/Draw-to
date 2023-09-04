using UnityEngine;

public class SaveDataSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private UISystem uiSystem;
    [SerializeField] private SoundSystem soundSystem;
    [SerializeField] private SkinSystem skinSystem;
    public int currentSound;
    void OnEnable()
    {
        currentSound = PlayerPrefs.GetInt("Sound", 1);
        data.level = PlayerPrefs.GetInt("Level0", 1);
        data.currentSkin = PlayerPrefs.GetInt("Skin", 0);
        data.isMusic = PlayerPrefs.GetInt("Music", 1) == 1;
        data.isVibration = PlayerPrefs.GetInt("Vibration", 1) == 1;
        data.keys = PlayerPrefs.GetInt("Keys", 0);
        data.avalableSkin = PlayerPrefs.GetInt("AvalableSkins",0 );
        data.score = PlayerPrefs.GetInt("Score",0 );
        data.noAds = PlayerPrefs.GetInt("NoAds", 0);
        data.daysCount = PlayerPrefs.GetInt("days",0);
        data.sessionCount = PlayerPrefs.GetInt("sessions",0);
        Invoke(nameof(SetSound), 0.1f);
    }   
    public void SaveSession()
    {
        PlayerPrefs.SetInt("days", data.daysCount);
        PlayerPrefs.SetInt("sessions", data.sessionCount);
    }
    private void SetSound()
    {
        data.isSound = currentSound == 1;
        Invoke(nameof(ChangeToggles), 0.1f);
    }

    private void ChangeToggles()
    {
        skinSystem.GetOpenSkins();
        uiSystem.ChangeUI();
        if (data.isSound)
        {
            soundSystem.OnSound();
        }
        else
        {
            soundSystem.OffSound();
        }

        if (data.isMusic)
        {
            soundSystem.SetMusic(true);
        }
        else
        {
            soundSystem.SetMusic(false);
        }

        if (data.isVibration)
        {
            soundSystem.SetVibration(true);
        }
        else
        {
            soundSystem.SetVibration(false);
        }
    }
    
}
    

