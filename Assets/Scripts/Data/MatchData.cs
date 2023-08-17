using UnityEngine;

[CreateAssetMenu(menuName = "Data/MatchData")]
public class MatchData : ScriptableObject
{
    public enum State
    {
        None,
        AppStart,
        InitializeLevel,
        MainMenu,
        InitializeTrees,
        WorcersTime,
        Game,
        Finish,
        GameOver,
        Reward,
        Bonus        
    }
    public int noAds;
    public SkinDataContainer skinDataContainer;
    public SoundDataContainer soundDataContainer;
    public int currentSkin;
    public int maxLevel;
    public float timeToFinish;
    public int score;
    public int level;
    public bool isSound;
    public bool isMusic;
    public bool isVibration;
    public int avalableSkin;
    public int keys;
    public Sprite zombeeWorldSprite;
    public Sprite pirateWorldSprite;
}
